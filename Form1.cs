using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using mshtml;

namespace robot
{
    public partial class Form1 : Form
    {
        HtmlDocument doc = null;
        int count = 0; // 첫 화면 오류 제거 카운터
        int BOARDTAGNUM = 13;
        int PAGENUM = 3; // board 배열 선언 숫자도 바꿔주어야 함

        Board[] board = new Board[3 * 10];
        BBBoard[] bbboard;

        string boardId = "B200902281833482321051";
        string userName = "";
        int rowIndex; // cell  클릭 후 인덱스 저장 -> row 추가할 때 사용
        int rowIndexBefore;
        int cellClickMode = 0;
        Random r = new Random();
        Say say;
        
        public Form1()
        {
            InitializeComponent();

            // 브라우저 스크립트 에러 무시
            browser.ScriptErrorsSuppressed = true;

            // say 초기화
            say = new Say();

            // 아이디 ini에 저장
            if (Program.loginSave == true)
            {
                Program.ini.SetIniValue("Login", "Id", Program.id);
                Program.ini.SetIniValue("Login", "Save", "true");

                if (Program.autoLogin == true)
                {
                    Program.ini.SetIniValue("Login", "Auto", "true");
                    Program.ini.SetIniValue("Login", "Password", Program.password);
                    checkBox1.Checked = true;
                }
                else
                {
                    Program.ini.SetIniValue("Login", "Auto", "false");
                    Program.ini.SetIniValue("Login", "Password", "");
                    checkBox1.Checked = false;
                }
            }
            else
            {
                Program.ini.SetIniValue("Login", "Id", "");
                Program.ini.SetIniValue("Login", "Save", "false");
            }

            // board 초기화
            for (int i = 0; i < PAGENUM * 10; i++)
                board[i] = new Board();

            browser.Navigate("https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp");
        }

        private void login()
        {
            doc = browser.Document as HtmlDocument;

            doc.GetElementById("id").SetAttribute("value", Program.id);
            doc.GetElementsByTagName("input")["UserPassWord"].SetAttribute("value", Program.password);
            doc.InvokeScript("doLogin");
        }

        private void webNavigate()
        {
           browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=" + boardId + "&nfirst=1");
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // font 수정
            //mshtml.HTMLDocument hdoc = doc.DomDocument as mshtml.HTMLDocument;
            //hdoc.execCommand("FontSize", false, "12pt");

            // 첫 로그인, 이름 저장, 학사 공지로 이동
            if (e.Url.ToString() == "http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp") {
                userName=browser.DocumentTitle.ToString().Split('-')[1].Split('/')[0];
                welcomeLabel.Text = userName + " 님 환영합니다 ^^";

                webNavigate();
                //this.Show();
                //Parent.Hide();
                count++;
            }

            // 로그인 화면 접속 후 로그인
            if (e.Url.ToString() == "https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp")
            {
                login();
            }

            // 최신 게시물 셀 클릭시 글 이동
            if (cellClickMode == 1)
            {
                cellClickMode = 0;
                return;
            }

            // 게시판에 접속후 파싱 (최신 게시글은 따로)
            if (e.Url.ToString().IndexOf("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=")!=-1)
            {
                // 헤더 바꿔줌
                gridView.Columns[3].HeaderText = "조회수";

                string url=e.Url.ToString().Substring(e.Url.ToString().IndexOf("&nfirst="));
                int page=Convert.ToInt32(url.Substring(8));

                IEnumerable<HtmlElement> titles = ElementsByClass(doc, "ltb_left");
                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "ltb_center");

                int docNum = elements.Count();
                int index;

                for (int i = 0; i < docNum / BOARDTAGNUM; i++)
                {
                    string[] rows = new string[4];
                    HtmlElement title = titles.ElementAt(i);

                    // title 길이 조정
                    // row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    /*int titleLen = 30;

                    if (title.InnerText.Count() > titleLen)
                    {
                        rows[0] += title.InnerText.Substring(0, titleLen);
                        rows[0] += "\r\n";
                        rows[0] += title.InnerText.Substring(titleLen);
                    }
                    else*/
                    {
                        rows[0] = title.InnerText;
                    }
                    rows[1] = elements.ElementAt(i * BOARDTAGNUM + 5).InnerText;
                    rows[2] = elements.ElementAt(i * BOARDTAGNUM + 7).InnerText;
                    rows[3] = elements.ElementAt(i * BOARDTAGNUM + 9).InnerText;

                    index = (page - 1) * 10 + i;

                    board[index].title = rows[0];
                    board[index].writer = rows[1];
                    board[index].date = rows[2];
                    board[index].viewCount = Convert.ToInt32(rows[3]);
                    board[index].page = page;
                    board[index].boardId = boardId;

                    for (int j = 0; j < 5; j++)
                    {
                        string javaUrl = title.InnerHtml.Substring(title.InnerHtml.IndexOf("javascript:"));
                        board[index].javascript[j] = javaUrl.Split('\"')[j * 2 + 1];
                    }
                    gridView.Rows.Add(rows);
                }
                if (page != PAGENUM)
                {
                    page++;
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=" + boardId + "&nfirst=" + page);
                    return;
                }

                // 첫 게시글 보여줌
                contentBox.Text = "";
                rowIndexBefore = rowIndex;
                rowIndex = 0;
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=" + boardId + "&bullid=" + board[0].javascript[1]);
                
                // 첫 로딩 이후, 게시글 바꿈 로딩 끝나고 브라우저 visible로 바꾸기
                if(count > 1)
                    browser.Visible = true;

                // 그리드 뷰 enable로 바꾸기
                // gridView.Enabled = true;

                // bb 접속
                if (count == 1)
                {
                    bbNavigate();
                    count++;
                }
            }

            // 최근 게시글 접속 후 파싱
            else if (e.Url.ToString().IndexOf("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp") != -1)
            {
                // 헤더 바꿔줌
                gridView.Columns[3].HeaderText = "게시판";

                string url = e.Url.ToString().Substring(e.Url.ToString().IndexOf("nfirst="));
                int page = Convert.ToInt32(url.Substring(7));

                IEnumerable<HtmlElement> titles = ElementsByClass(doc, "ltb_left");
                IEnumerable<HtmlElement> elements = ElementsByClass(doc,"ltb_center");

                int docNum = elements.Count();
                int index;

                for (int i = 0; i < docNum / 11; i++)
                {
                    string[] rows = new string[4];
                    HtmlElement title = titles.ElementAt(i);

                    // title 길이 조정
                    // row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    /*int titleLen = 30;

                    if (title.InnerText.Count() > titleLen)
                    {
                        rows[0] += title.InnerText.Substring(0, titleLen);
                        rows[0] += "\r\n";
                        rows[0] += title.InnerText.Substring(titleLen);
                    }
                    else*/
                    {
                        rows[0] = title.InnerText;
                    }
                    rows[1] = elements.ElementAt(i * 11 + 5).InnerText;
                    rows[2] = elements.ElementAt(i * 11 + 7).InnerText;
                    rows[3] = elements.ElementAt(i * 11 + 3).InnerText;

                    index = (page - 1) * 10 + i;

                    board[index].title = rows[0];
                    board[index].writer = rows[1];
                    board[index].date = rows[2];
                    board[index].boardName = rows[3];
                    //board[index].viewCount = Convert.ToInt32(rows[3]);
                    board[index].page = page;
                    board[index].boardId = boardId;

                    string javaUrl=title.InnerHtml.Substring(title.InnerHtml.IndexOf("Javascript:"));
                    // amp 생기는 이유??
                    board[index].javascript[0] = javaUrl.Split('\"')[1].Replace("amp;","");
                    
                    gridView.Rows.Add(rows);

                }

                if (page != PAGENUM)
                {
                    page++;
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp" + "?nfirst=" + page);
                    return;
                }

                // 첫 게시글 보여줌
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/" + board[0].javascript[0]);
                
                // 그리드 뷰 enable로 바꾸기
                gridView.Enabled = true;

                // 첫 로딩 이후, 게시글 바꿈 로딩 끝나고 브라우저 visible로 바꾸기
                if (count > 1)
                    browser.Visible = true;
            }

            // 셀 클릭했을 떄
            if (e.Url.ToString().IndexOf("BB_BoardView") > 0)
            {
                /*** 그리드 뷰 셀에 게시글 추가
                HtmlElementCollection content = doc.GetElementsByTagName("font");
                string cont="";

                MessageBox.Show(rowIndex+" , "+rowIndexBefore);

                if (rowIndexBefore == rowIndex)
                {
                    gridView.Rows.RemoveAt(rowIndexBefore + 1);
                    return;
                }

                // 이전 클릭 글 지우기
                gridView.Rows.RemoveAt(rowIndexBefore+1);

                for (int i = 0; i < content.Count; i++)
                {
                    if (content[i].InnerText == null)
                    {
                        continue;
                    }

                    else if (content[i].InnerText.Count() > gridView.Columns[1].Width)
                    {
                        cont += content[i].InnerText.Substring(0, gridView.Columns[1].Width);
                        cont += content[i].InnerText.Substring(gridView.Columns[1].Width);
                        cont += "\r\n";
                    }
                    else
                    {
                        cont += content[i].InnerText;
                        cont += "\r\n";
                    }
                }

                contentBox.Text=cont;
                
                DataGridViewRow row=new DataGridViewRow();
                row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                row.CreateCells(gridView);
                row.Cells[0].Value = cont;
                gridView.Rows.Insert(rowIndex+1, row);*/

            }

            //====================== black board ===========================//

            if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/portal/frameset.jsp")
            {
                browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements");
            }

            else if (e.Url.ToString()=="http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements") {
                HtmlElementCollection options = doc.GetElementsByTagName("Option");

                // bb 게시판 id
                bbboard = new BBBoard[options.Count-3];

                int j = 0;
                string n;

                for (int i = 3; i < options.Count; i++)
                {
                    n = options[i].InnerText.Replace("-", "");
                    // Open Study 제외
                    if (n.IndexOf("Open Study") != -1 || n.IndexOf("Organizations") != -1)
                    {
                        j++;
                        continue;
                    }
                    bbboard[i - 3 - j] = new BBBoard();
                    bbboard[i - 3 - j].url = options[i].OuterHtml.Split('=')[1].Split('>')[0];
                    bbboard[i - 3 - j].name = n;
                    bbList.Items.Add(bbboard[i - 3 - j].name);
                }

                //bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=_11194_1

                browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/tmaxsso/first_cs.aspx ");
            }

            if (e.Url.ToString() == "http://library.unist.ac.kr/DLiWeb25Eng/default.aspx")
            {
                // bb 에서 포탈 anouncement로 이동
                contentBox.Text = "";
                rowIndexBefore = rowIndex;
                rowIndex = 0;
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=" + boardId + "&bullid=" + board[0].javascript[1]);
                browser.Visible = true;

                // 처음  false 이후 계속  true
                browser.Visible = true;
                gridView.Enabled = true;
                portalList.Enabled = true;
                bbList.Enabled = true;
                libraryList.Enabled = true;

                // gridview 로딩 끝난 후 클릭 가능하게
                gridView.Enabled = true;
            }
        }
        /*
        public void parsing(int page)
        {
            //if (page != 1)
            {
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid="+boardId+"&nfirst="+page);
            }
            /*
            IEnumerable<HtmlElement> titles = ElementsByClass(doc, "ltb_left");
            IEnumerable<HtmlElement> elements = ElementsByClass(doc, "ltb_center");

            int docNum = elements.Count();
            int index;
            
            for (int i = 0; i < docNum / BOARDTAGNUM; i++)
            {
                string[] rows = new string[4];
                HtmlElement title = titles.ElementAt(i);

                // title 길이 조정
                // row.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                /*int titleLen = 30;

                if (title.InnerText.Count() > titleLen)
                {
                    rows[0] += title.InnerText.Substring(0, titleLen);
                    rows[0] += "\r\n";
                    rows[0] += title.InnerText.Substring(titleLen);
                }
                ////////////////else
                {
                    rows[0] = title.InnerText;
                }
                rows[1] = elements.ElementAt(i * 13 + 5).InnerText;
                rows[2] = elements.ElementAt(i * 13 + 7).InnerText;
                rows[3] = elements.ElementAt(i * 13 + 9).InnerText;

                index = (page - 1) * 10 + i;
                
                board[index].title=rows[0];
                board[index].writer = rows[1];
                board[index].date = rows[2];
                board[index].viewCount = Convert.ToInt32(rows[3]);
                board[index].page = page;
                board[index].boardId = boardId;

                for (int j = 0; j < 5; j++)
                {
                    board[index].javascript[j] = title.InnerHtml.Split('\"')[j*2+1];
                }
                gridView.Rows.Add(rows);
            }
        }*/

        static IEnumerable<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    yield return e;
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void boardBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            browser.Visible = false;
            ComboBox comboBox = (ComboBox) sender;

            // 이전 데이터 삭제
            for (int i = 0; i < PAGENUM * 10; i++)
                board[i] = new Board();

            while (gridView.Rows.Count != 0)
            {
                gridView.Rows.RemoveAt(0);
            }

            switch(comboBox.SelectedIndex) {
                case 0:
                    // 학사 공지
                    boardId = "B200902281833482321051";
                    webNavigate();
                    break;
                case 1:
                    // 전체 공지
                    boardId="B200902281833016691048";
                    webNavigate();

                    break;
                case 2:
                    // 대학원 공지
                    boardId = "B201003111719010571299";
                    webNavigate();
                    break;
                case 3:
                    // 최신 게시물
                    // http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp 
                    boardId = "B201003111719010571299";
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp?nfirst=1");
                    break;
                case 4:
                    // 개선 및 제안
                    boardId = "B200805221624473331040";
                    webNavigate();
                    break;
                case 5:
                    // Q & A
                    boardId = "B200806120956049151016";
                    webNavigate();
                    break;
            }
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 혹시라도 나오기전에 누르면 true
            browser.Visible = true;

            cellClickMode = 1;

            // 헤더 클릭시 종료
            if (e.RowIndex < 0)
                return;

            if (boardId == "B201003111719010571299")
            {
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/" + board[e.RowIndex].javascript[0]);
            }
            else
            {
                contentBox.Text = "";
                rowIndexBefore = rowIndex;
                rowIndex = e.RowIndex;
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=" + boardId + "&bullid=" + board[e.RowIndex].javascript[1]);
            }
            //browser.Url = new Uri("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardToHtml.jsp?boardid=B200902281833482321051&bullid=BB201301181146301438492&comp_id=7007886&tablename=tBB_basic");
            //doc.InvokeScript("changePage", new object[] {2});
            //string[] arg = board[e.RowIndex].javascript;
            //doc.InvokeScript("clickBulletin", new object[] {arg[0], arg[1], arg[2], arg[3], arg[4]});
            //doc.InvokeScript("saveToHtml");
        }

        private void bbNavigate()
        {
            browser.Navigate("http://portal.unist.ac.kr/EP/tmaxsso/runUEE.jsp?host=bb");
        }

        // 포탈 리스트 박스 클릭
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            browser.Visible = false;
            ListBox comboBox = (ListBox)sender;

            // bb 클릭 클리어
            bbList.ClearSelected();

            // 이전 데이터 삭제
            for (int i = 0; i < PAGENUM * 10; i++)
                board[i] = new Board();

            while (gridView.Rows.Count != 0)
            {
                gridView.Rows.RemoveAt(0);
            }

            switch (comboBox.SelectedIndex)
            {
                case 0:
                    // 학사 공지
                    boardId = "B200902281833482321051";
                    webNavigate();
                    break;
                case 1:
                    // 전체 공지
                    boardId = "B200902281833016691048";
                    webNavigate();

                    break;
                case 2:
                    // 대학원 공지
                    boardId = "B201003111719010571299";
                    webNavigate();
                    break;
                case 3:
                    // 최신 게시물
                    // http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp 
                    boardId = "B201003111719010571299";
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp?nfirst=1");
                    break;
                /*case 4:
                    // 개선 및 제안
                    boardId = "B200805221624473331040";
                    webNavigate();
                    break;*/
                /*case 4:
                    // Q & A
                    boardId = "B200806120956049151016";
                    webNavigate();
                    break;*/
            }
        }

        private void bbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // bb 클릭 클리어
            // portalList.ClearSelected();

            ListBox comboBox = (ListBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                while (gridView.Rows.Count != 0)
                {
                    gridView.Rows.RemoveAt(0);
                }

                browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=" + bbboard[comboBox.SelectedIndex].url);
            }
        }

        // 자동 로그인 체크 박스
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked == true && count!=0)
            {
                DialogResult result = MessageBox.Show("개인정보가 유출될 수 있습니다.\r\n\r\n자동 로그인을 하시겠습니까? :[", "Robot의 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    check.Checked = false;
                    return;
                }

                Program.ini.SetIniValue("Login", "Auto", "true");
                Program.ini.SetIniValue("Login", "Save", "true");
                Program.ini.SetIniValue("Login", "Id", Program.id);
                Program.ini.SetIniValue("Login", "Password", Program.password);
            }
            else
            {
                Program.ini.SetIniValue("Login", "Auto", "false");
                Program.ini.SetIniValue("Login", "Save", "false");
                Program.ini.SetIniValue("Login", "Id", "");
                Program.ini.SetIniValue("Login", "Password", "");
            }
        }

        private void browser_VisibleChanged(object sender, EventArgs e)
        {
            //loadingLabel.Text=say.say[r.Next(0, say.say.Count()) % say.say.Count()];
        }

        private void libraryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            browser.Visible = false;
            ListBox comboBox = (ListBox)sender;

            // bb 클릭 클리어
            bbList.ClearSelected();

            

            switch (comboBox.SelectedIndex)
            {

                case 0:
                    // 도서 검색
                    
                    break;
                case 1:
                    // 스터디룸 예약
                    browser.Navigate("http://library.unist.ac.kr/dliweb25eng/html/EN/studyRoom.html");
                    break;
                case 2:
                    // 열람실 좌석 현황
                    browser.Navigate("http://seat.unist.ac.kr/EZ5500/RoomStatus/room_status.asp");
                    break;
            }
            browser.Visible = true;
        }

        private void settingLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed by Kim Tae Hoon.");
        }
    }
}
