using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using mshtml;
using System.Web;
using System.Xml;

namespace robot
{
    public partial class Form1 : Form
    {
        HtmlDocument doc = null;
        int PORTALBOARDNUM = 4;
        int count = 0; // 첫 화면 오류 제거 카운터
        int BOARDTAGNUM = 13;

        BB[] bbboard;

        string boardId = "B200902281833482321051";
        string userName = "";
        int rowIndex; // cell  클릭 후 인덱스 저장 -> row 추가할 때 사용
        int rowIndexBefore;
        int cellClickMode = 0;

        int bbDeletedCount = 0; // bb anouncement에서 빠진 게시글 수
        int bbCount = 0;

        int iconCount = 0; // welcomeLabel 이모티콘 모양

        string bookQuery = ""; // 책 검색 쿼리
        Book[] books;
        string bookReviewUrl = "";
        string isbn = ""; // 책 평점을 위한 변수

        string phoneNum = ""; // 스터디룸 예약을 위한 변수
        string email = ""; // 스터디룸 예약을 위한 변수
        string thisYear = "2013";

        Random r = new Random();

        /****************************/
        Portal portal;
        Board[] board = new Board[3 * 10];
        int PAGENUM = 3; // board 배열 선언 숫자도 바꿔주어야 함
        /****************************/

        public Form1()
        {
            InitializeComponent();

            // 브라우저 스크립트 에러 무시
            browser.ScriptErrorsSuppressed = true;

            autoLoginSetup();

            browser.Navigate("https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp");

            // 책 검색 옵션 초기화
            bookOption1.SelectedIndex = 0;
            bookOption2.SelectedIndex = 1;
            bookOperator.SelectedIndex = 0;
        }

        private void autoLoginSetup()
        {
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
        }

        private void showGridView(int boardId = 1)
        {
            Board[] boards=portal.getBoard(boardId);
            int i = 0;

            foreach (Board b in boards)
            {
                gridView.Rows.Add(b.rows);

                // 셀 글자 색 추가
                if (b.color != Color.Black)
                 {
                    // 글자 볼드 추가
                    if (b.bold == true)
                    {
                        gridView.Rows[i].Cells[1].Style = new DataGridViewCellStyle
                        {
                            ForeColor = b.color,
                            Font = new Font(gridView.DefaultCellStyle.Font, FontStyle.Bold)
                        };
                    }
                    else
                    {
                        gridView.Rows[i].Cells[1].Style = new DataGridViewCellStyle { ForeColor = b.color };
                    }
                }

                // 글자 볼드 추가
                if (b.bold == true)
                {
                    gridView.Rows[i].Cells[1].Style.Font = new Font(gridView.DefaultCellStyle.Font, FontStyle.Bold);
                }

                i++;
            }
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // font 수정
            //mshtml.HTMLDocument hdoc = doc.DomDocument as mshtml.HTMLDocument;
            //hdoc.execCommand("FontSize", false, "12pt");

            if(portalList.SelectedValue!=null && portalList.SelectedValue.ToString()!="스터디룸 예약")
                studyGrid.Visible = false;

            if (portalList.SelectedValue != null && portalList.SelectedValue.ToString() != "스터디룸 예약")
            {
                roomNumberBox.Visible = false;
                roomNumberLabel.Visible = false;
            }

            // 첫 로그인, 이름 저장, 학사 공지로 이동
            if (e.Url.ToString() == "http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp") {
                userName=browser.DocumentTitle.ToString().Split('-')[1].Split('/')[0];

                portal = new Portal(browser.Document.Cookie);
                showGridView();

                browser.Navigate("http://portal.unist.ac.kr/EP/tmaxsso/runUEE.jsp?host=bb");
            }

            // 로그인 화면 접속 후 로그인
            if (e.Url.ToString() == "https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp")
            {
                doc = browser.Document as HtmlDocument;

                doc.GetElementById("id").SetAttribute("value", Program.id);
                doc.GetElementsByTagName("input")["UserPassWord"].SetAttribute("value", Program.password);
                doc.InvokeScript("doLogin");
            }

            // 최신 게시물 셀 클릭시 글 이동
            if (cellClickMode == 1)
            {
                cellClickMode = 0;
                return;
            }

            // 최근 게시글 접속 후 파싱
            else if (e.Url.ToString().IndexOf("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp") != -1)
            {/*
                // 헤더 바꿔줌
                gridView.Columns[4].HeaderText = "게시판";

                string url = e.Url.ToString().Substring(e.Url.ToString().IndexOf("nfirst="));
                int page = Convert.ToInt32(url.Substring(7));

                IEnumerable<HtmlElement> titles = ElementsByClass(doc, "ltb_left");
                IEnumerable<HtmlElement> elements = ElementsByClass(doc,"ltb_center");

                int docNum = elements.Count();
                int index;

                for (int i = 0; i < docNum / 11; i++)
                {
                    string[] rows = new string[5];
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
                    else*//*
                    {
                        rows[1] = title.InnerText;
                    }
                    rows[2] = elements.ElementAt(i * 11 + 5).InnerText;
                    rows[3] = elements.ElementAt(i * 11 + 7).InnerText;
                    rows[4] = elements.ElementAt(i * 11 + 3).InnerText;
                    //rows[0] = ""; // 전체공지, 학사공지, 대학원공지에서 new, 공지글 표시용

                    index = (page - 1) * 10 + i;

                    board[index].title = rows[1];
                    board[index].writer = rows[2];
                    board[index].date = rows[3];
                    board[index].boardName = rows[4];
                    //board[index].viewCount = Convert.ToInt32(rows[3]);
                    board[index].page = page;
                    board[index].boardId = boardId;

                    string javaUrl=title.InnerHtml.Substring(title.InnerHtml.IndexOf("Javascript:"));
                    // amp 생기는 이유??
                    //board[index].javascript[0] = javaUrl.Split('\"')[1].Replace("amp;","");
                    
                    gridView.Rows.Add(rows);

                }

                if (page != PAGENUM)
                {
                    page++;
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp" + "?nfirst=" + page);
                    return;
                }

                // 첫 게시글 보여줌
                //browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/" + board[0].javascript[0]);
                
                // 그리드 뷰 enable로 바꾸기
                gridView.Enabled = true;

                // 첫 로딩 이후, 게시글 바꿈 로딩 끝나고 브라우저 visible로 바꾸기
                if (count > 1)
                    browser.Visible = true;*/
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

            if (e.Url.ToString().IndexOf("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=") != -1)
            {
                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "clearfix");

                /*string html = "<html  lang=\"en-US\"><style type=\"text/css\">\r\nbody { font-family:'Arial'; }\r\n.font-test { font:bold 24pt 'Arial'; }\r\n</style><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">";

                foreach (HtmlElement ele in elements) {
                    html+=ele.InnerHtml.ToString();
                    html += "<hr/>";
                }

                browser.DocumentText = html;*/
                browser.Visible = true;
            }

            if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/portal/frameset.jsp")
            {
                browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements");
            }

            else if (e.Url.ToString()=="http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements") {
                HtmlElementCollection options = doc.GetElementsByTagName("Option");

                // bb 게시판 id
                bbboard = new BB[options.Count-3];

                int j = 0;
                string n;

                portalList.Items.Add("-------------------");
                for (int i = 3; i < options.Count; i++)
                {
                    n = options[i].InnerText.Replace("-", "");
                    // Open Study 제외
                    if (n.IndexOf("Open Study") != -1 || n.IndexOf("Organizations") != -1)
                    {
                        j++;
                        bbDeletedCount++;
                        continue;
                    }
                    bbboard[i - 3 - j] = new BB();
                    bbboard[i - 3 - j].url = options[i].OuterHtml.Split('=')[1].Split('>')[0];
                    bbboard[i - 3 - j].name = n;
                    portalList.Items.Add(bbboard[i - 3 - j].name);

                    if (count < 3)
                    {
                        bbCount++;
                    }
                }

                //bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=_11194_1

                browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/tmaxsso/first_cs.aspx ");
            }

            if (e.Url.ToString() == "http://library.unist.ac.kr/DLiWeb25Eng/default.aspx")
            {
                portalList.Items.Add("-------------------");
                portalList.Items.Add("도서 검색");
                portalList.Items.Add("스터디룸 예약");
                portalList.Items.Add("열람실 좌석 현황");

                // bb 에서 포탈 anouncement로 이동
                contentBox.Text = "";
                rowIndexBefore = rowIndex;
                rowIndex = 0;
               // browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=" + boardId + "&bullid=" + board[0].javascript[1]);
                browser.Visible = true;

                // 처음  false 이후 계속  true
                browser.Visible = true;
                gridView.Enabled = true;
                portalList.Enabled = true;
                bbList.Enabled = true;
                libraryList.Enabled = true;

                // gridview 로딩 끝난 후 클릭 가능하게
                gridView.Enabled = true;

                welcomeLabel.Text = userName + " 님 환영합니다 :-)";
            }

            // 스터디룸 예약
            if (e.Url.ToString().IndexOf("library.unist.ac.kr/dliweb25eng/studyroom/detail.aspx?") != -1)
            {
                HtmlElement table = doc.GetElementsByTagName("table")[1];

                /*browser.DocumentText = "<html>\r\n<style type=\"text/css\">\r\nbody { font-family:'Arial'; }\r\n.font-test { font:bold 24pt 'Arial'; }\r\n</style>" + 
                    //http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoA.gif
                    //table.OuterHtml.ToString().Replace("/DLiWeb25Eng/html/images/ico/icoA.gif", "http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoA.gif").Replace("DLiWeb25Eng/html/images/ico/icoN.gif", "http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoN.gif")
                    table.OuterHtml.ToString().Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoA.gif\" alert=\"Expire\">", "E").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoN.gif\" alert=\"Reserved\">", "R").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoU.gif\" alert=\"Commit\">", "E")
                    + "\r\n</html>";*/
                //string parsing = table.OuterHtml.ToString().Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoA.gif\" alert=\"Expire\">", "E").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoN.gif\" alert=\"Reserved\">", "R").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoU.gif\" alert=\"Commit\">", "E");
                
                HtmlElementCollection tds = table.GetElementsByTagName("td");

                // study grid 내용 지우기
                while (studyGrid.Rows.Count != 0)
                {
                    studyGrid.Rows.RemoveAt(0);
                }

                // study room grid 내용 추가
                for (int i = 0; i < tds.Count; i+=25)
                {
                    string[] rows = new string[25];
                    for (int j = 0; j < 25; j++)
                    {
                        if (j % 25 == 0)
                        {
                            rows[0] = tds[i+j].InnerText;
                        }
                        else
                        {
                            if (tds[i+j].GetElementsByTagName("a")[0].InnerHtml.IndexOf("icoA.gif") != -1)
                            {
                                rows[j] = "E";
                            }
                            else if (tds[i+j].GetElementsByTagName("a")[0].InnerHtml.IndexOf("icoN.gif") != -1)
                            {
                                rows[j] = "R";
                            }
                            else
                            {
                                rows[j] = "-";
                            }
                        }
                    }

                    studyGrid.Rows.Add(rows);

                    // 오늘 날짜 줄 표시
                    if (Convert.ToInt32(rows[0].Substring(0, 2)) == DateTime.Now.Month && Convert.ToInt32(rows[0].Substring(3)) == DateTime.Now.Day)
                        studyGrid.Rows[i / 25].DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.PowderBlue };
                }

                browser.Visible = false;
                studyGrid.Visible = true;
                roomNumberBox.Visible = true;
                roomNumberLabel.Visible = true;
            }

            // 책 검색 쿼리
            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Results.aspx?") != -1)
            {
                browser.Visible = true;
                while (bookGridView.Rows.Count != 0)
                {
                    bookGridView.Rows.RemoveAt(0);
                }

                bookListGrid.Visible = true;

                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "item");

                books = new Book[elements.Count()];

                string[] rows = new string[5];

                for (int i = 0; i < elements.Count(); i++)
                {

                    books[i] = new Book();
                    string html = elements.ElementAt(i).InnerHtml;

                    if (html.IndexOf("no thumbnail") != -1)
                    {
                        books[i].thumbnail = "";
                    }
                    else
                    {
                        books[i].thumbnail = html.Substring(html.IndexOf("thumb.axd?url=")).Split('\"')[0];
                    }

                    rows[0] = books[i].title = elements.ElementAt(i).GetElementsByTagName("label")[0].GetAttribute("title").Split('/')[0].Replace("선택하기","");
                    rows[1] = books[i].author = html.Substring(html.IndexOf("author\">")).Split('>')[1].Split('<')[0];
                    rows[2] = books[i].publisher = html.Substring(html.IndexOf("publisher\">")).Split('>')[1].Split('<')[0];
                    rows[3] = books[i].publishYear = html.Substring(html.IndexOf("publishyear\">")).Split('>')[1].Split('<')[0];
                    rows[4] = books[i].isbn = html.Substring(html.IndexOf("isbn\">")).Split('>')[1].Split('<')[0];

                    // 도서 상태를 위한 cid
                    books[i].cid = elements.ElementAt(i).GetElementsByTagName("input")[0].GetAttribute("value");

                    if (html.IndexOf("Domestic Books") != -1)
                    {
                        books[i].kind = "국내 서적";
                    }

                    bookGridView.Rows.Add(rows);
                }

                // 첫번째 책 클릭 후 사진 보여줌
                if (bookGridView.RowCount == 0)
                    return;

                bookGridView.Rows[0].Selected = true;
            }

            // 책 이미지 뽑아오기
            /*if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25/comp/search/thumb.axd?url=") != -1)
            {
                bookPic.Visible = true;
            }*/

            // 도서 평점 추가
            if (e.Url.ToString().IndexOf("http://book.naver.com/bookdb/book_detail.nhn?bid=") != -1)
            {
                bookReview.Text = "평점 : ";
                string html = doc.ToString();
                bookReviewUrl="";

                HtmlElement element = ElementsByClass(doc, "txt_desc").ElementAt(0);
                //bookReview.Text += element.GetElementsByTagName("strong")[0].InnerText;
                //bookReview.Text += html.Substring(html.IndexOf("네티즌리뷰")).Split('건')[0];
                bookReview.Text += element.InnerText.Split('|')[0] + "(" + element.InnerText.Split('|')[1].Substring(6) + ")";
                bookReviewUrl = element.GetElementsByTagName("a")[0].GetAttribute("href");
            }

            // 도서 상태 추가
            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/comp/search/SearchHandler.aspx?action=stock&cid=") != -1)
            {
                string[] rows = new string[4];

                while (bookListGrid.Rows.Count != 0)
                {
                    bookListGrid.Rows.RemoveAt(0);
                }

                //IEnumerable<HtmlElement> elements = ElementsByClass(doc, "stock_callnumber");

                for (int i = 1; i < doc.GetElementsByTagName("tr").Count; i++)
                {
                    rows[0] = doc.GetElementsByTagName("tr")[i].GetElementsByTagName("td")[1].InnerText;
                    rows[1] = doc.GetElementsByTagName("tr")[i].GetElementsByTagName("td")[2].InnerText;
                    rows[2] = doc.GetElementsByTagName("tr")[i].GetElementsByTagName("td")[3].InnerText;
                    rows[3] = doc.GetElementsByTagName("tr")[i].GetElementsByTagName("td")[4].InnerText;

                    bookListGrid.Rows.Add(rows);
                }

                XmlDocument docX = new XmlDocument();
                docX.Load("http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=" + isbn);

                XmlNodeList elemList = docX.GetElementsByTagName("link");
                for (int i = 0; i < elemList.Count; i++)
                {
                    browser.Navigate(elemList[i].InnerXml);
                }
            }

            // 스터디 날짜 선택 시 이벤트
            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/studyroom/reserve.aspx?m_var=112&roomid=1&rdate=") != -1)
            {
                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "empty_trbg");
                HtmlElement info = elements.ElementAt(6);

                studyPhoneNumber.Text = phoneNum = info.GetElementsByTagName("input")[0].GetAttribute("value");
                studyEmail.Text = email = info.GetElementsByTagName("input")[1].GetAttribute("value");
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
        
        // 클래스 이름으로 htmlelment 받는 함수
        static IEnumerable<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    yield return e;
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        // 보드 리스트 박스
        private void boardBox_SelectedIndexChanged(object sender, EventArgs e)
        {/*
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
            }*/
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
               // browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/" + board[e.RowIndex].javascript[0]);
            }
            else
            {
                contentBox.Text = "";
                rowIndexBefore = rowIndex;
                rowIndex = e.RowIndex;
               // browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=" + boardId + "&bullid=" + board[e.RowIndex].javascript[1]);
            }
            //browser.Url = new Uri("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardToHtml.jsp?boardid=B200902281833482321051&bullid=BB01181146301438492&comp_id=7007886&tablename=tBB_basic");
            //doc.InvokeScript("changePage", new object[] {2});
            //string[] arg = board[e.RowIndex].javascript;
            //doc.InvokeScript("clickBulletin", new object[] {arg[0], arg[1], arg[2], arg[3], arg[4]});
            //doc.InvokeScript("saveToHtml");
        }

        // 포탈 리스트 박스 클릭
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridView.Visible = true;
            browser.Visible = false;
            studyGroup.Visible = false;
            bookGroup.Visible = false;
            studyGrid.Visible = false;
            bookInfoGroup.Visible = false;
            ListBox comboBox = (ListBox)sender;

            // bb 클릭 클리어
            bbList.SelectedIndex = -1;
            libraryList.SelectedIndex = -1;

            // 이전 데이터 삭제
            for (int i = 0; i < PAGENUM * 10; i++)
                board[i] = new Board();

            while (gridView.Rows.Count != 0)
            {
                gridView.Rows.RemoveAt(0);
            }

            // 포탈 리스트
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    // 학사 공지
                    boardId = "B200902281833482321051";

                    break;
                case 1:
                    // 전체 공지
                    boardId = "B200902281833016691048";

                    break;
                case 2:
                    // 대학원 공지
                    boardId = "B201003111719010571299";

                    break;
                case 3:
                    // 최신 게시물
                    // http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp 
                    boardId = "B201003111719010571299";
                    browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp?nfirst=1");
                    break;
                case 4:
                    return;
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

            // BB 리스트
            if (comboBox.SelectedIndex > PORTALBOARDNUM && comboBox.SelectedIndex < PORTALBOARDNUM + bbboard.Count() - 4)
            {
                gridView.Visible = true;

                if (comboBox.SelectedIndex != -1)
                {
                    while (gridView.Rows.Count != 0)
                    {
                        gridView.Rows.RemoveAt(0);
                    }

                   browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=" + bbboard[comboBox.SelectedIndex - PORTALBOARDNUM - 1].url);
                }

                browser.Visible=true;
                studyGrid.Visible = false;
                return;
            }

            // ------------ 스킵
            if (comboBox.SelectedIndex == PORTALBOARDNUM + bbboard.Count() - 4)
            {
                browser.Visible = true;
                return;
            }

            // library 리스트
            if (comboBox.SelectedIndex > PORTALBOARDNUM + bbboard.Count() - 4)
            {
                browser.Visible = true;

                switch (comboBox.SelectedIndex - PORTALBOARDNUM - bbCount - 2)
                {
                    case 0:
                        // 도서 검색
                        browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Advance.aspx?");
                        bookGroup.Visible = true;
                        bookInfoGroup.Visible = true;
                        gridView.Visible = false;
                        studyGroup.Visible = false;
                        browser.Visible = false;
                        studyGrid.Visible = false;
                        roomNumberBox.Visible = false;
                        roomNumberLabel.Visible = false;
                        break;
                    case 1:
                        // 스터디룸 예약
                        browser.Navigate("http://library.unist.ac.kr/dliweb25eng/studyroom/detail.aspx?m_var=112&roomid=1");
                        roomNumberBox.SelectedIndex = 0;
                        gridView.Visible = false;
                        studyGroup.Visible = true;
                        bookGroup.Visible = false;
                        bookInfoGroup.Visible = false;
                        browser.Visible = false;
                        break;
                    case 2:
                        // 열람실 좌석 현황
                        browser.Navigate("http://seat.unist.ac.kr/EZ5500/RoomStatus/room_status.asp");
                        browser.Visible = true;
                        studyGroup.Visible = false;
                        studyGrid.Visible = false;
                        roomNumberBox.Visible = false;
                        roomNumberLabel.Visible = false;
                        break;
                }
            }
        }

        private void bbList_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            // bb 클릭 클리어
            portalList.SelectedIndex = -1;
            libraryList.SelectedIndex = -1;

            ListBox comboBox = (ListBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                while (gridView.Rows.Count != 0)
                {
                    gridView.Rows.RemoveAt(0);
                }

                browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=" + bbboard[comboBox.SelectedIndex].url);
            }*/
        }

        // 자동 로그인 체크 박스
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked == true && count!=0)
            {
                DialogResult result = MessageBox.Show("개인정보가 유출될 수 있습니다.\r\n자동 로그인을 하시겠습니까? :[", "Robot의 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
            if (check.Checked == false)
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
            /*browser.Visible = false;
            ListBox comboBox = (ListBox)sender;

            // bb 클릭 클리어
            bbList.ClearSelected();
            portalList.ClearSelected();

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
            browser.Visible = true;*/
        }

        private void settingLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed by Kim Tae Hoon ಠ_ಠ");
        }

        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            iconCount++;

            if (e.Url.ToString().IndexOf("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=") != -1)
            {
                browser.Visible = false;
            }

            // 스터디룸 리스트 볼 때 브라우저 잠시 숨기기
            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/dliweb25eng/studyroom/detail.aspx?") != -1)
            {
                browser.Visible = false;
            }

            if (iconCount % 5 == 0)
            {
                loadingLabel.Text = "o_O";
            }
            else if (iconCount % 5 == 1)
            {
                loadingLabel.Text = "o_o";
            }
            else if (iconCount % 5 == 2)
            {
                loadingLabel.Text = "o_o";
            }
            else if (iconCount % 5 == 3)
            {
                loadingLabel.Text = "O_o";
            }
            else if (iconCount % 5 == 4)
            {
                loadingLabel.Text = "o_o";
            }

            if (welcomeLabel.Text.IndexOf("님") > 0)
            {
                return;
            }

            if (iconCount % 6 == 0)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다.";
            }
            else if (iconCount % 6 == 1)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다..";
            }
            else if (iconCount % 6 == 2)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다...";
            }
            else if (iconCount % 6 == 3)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다..";
            }
            else if (iconCount % 6 == 4)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다.";
            }
            else if (iconCount % 6 == 5)
            {
                welcomeLabel.Text = "이름을 확인 중 입니다";
            }
            /*else if (iconCount % 8 == 4)
            {
                welcomeLabel.Text = "당신의 이름을 확인 중 입니다  0_o";
            }
            else if (iconCount % 8 == 5)
            {
                welcomeLabel.Text = "당신의 이름을 확인 중 입니다  o_o";
            }
            else if (iconCount % 8 == 6)
            {
                welcomeLabel.Text = "당신의 이름을 확인 중 입니다  o_0";
            }
            else if (iconCount % 8 == 7)
            {
                welcomeLabel.Text = "당신의 이름을 확인 중 입니다  o_O";
            }*/
        }

        private void roomNumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            browser.Navigate("http://library.unist.ac.kr/dliweb25eng/studyroom/detail.aspx?m_var=112&roomid=" + (comboBox.SelectedIndex+1).ToString());
        }

        private Color ConvertColor_PhotoShopStyle_toRGB(string photoShopColor)
        {
            int red, green, blue;
            red = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(1, 2), 16));
            green = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(3, 2), 16));
            blue = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(5, 2), 16));

            return Color.FromArgb(red, green, blue);
        }

        // study room gridv
        private void studyGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            DataGridViewRow row = grid.Rows[grid.Rows.Count - 1];

            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Value == "E")
                {
                    row.Cells[i].Style = new DataGridViewCellStyle { ForeColor=Color.White, BackColor=Color.CadetBlue };
                }
                if (row.Cells[i].Value == "R")
                {
                    row.Cells[i].Style = new DataGridViewCellStyle { ForeColor = Color.White, BackColor = Color.IndianRed };
                }
            }
        }

        private void bookSearch_Click(object sender, EventArgs e)
        {
            queryMake(); // 쿼리 만듬

            // 도서 상태 초기화
            while (bookListGrid.Rows.Count != 0)
            {
                bookListGrid.Rows.RemoveAt(0);
            }

            bookTitle.Text = "책 제목";
            bookReview.Text = "";
            bookReviewUrl = "";

            if (bookQuery != "")
            {
                string url = "http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Results.aspx?" + bookQuery;
                browser.Navigate(url);
            }
            //http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Results.aspx?method=2&field=TITL,AUTH,PUBN&keyword=%ED%95%B4%ED%82%B9,%ED%95%B4%ED%82%B9,%ED%95%B4%ED%82%B9&operator=0,1,3&branch=01&classid=24,27,1,60,32,65,21,23,25,39,75,2,22,41,38,74,88,52,33,6,19,80,29,59,85,89,63,5,28,16,77,30,73,53,34,64,79,26,90,35,3,4,15,20,42,76,86,91&max=300&classifyname=KDC&classify=&cntperpage=20&viewoption=1&sort=DEFAULT
        }

        public void queryMake()
        {
            string query = "method=2";

            if (bookQuery1 != null && bookQuery2 == null)
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery1.Text);
                query += "&field=";

                if (bookOption1.SelectedItem.ToString() == "제목")
                    query += "TITL";
                else if (bookOption1.SelectedItem.ToString() == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }
                query += "&operator=0";
            }
            else if (bookQuery1 == null && bookQuery2 != null)
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery2.Text);
                query += "&field=";

                if (bookOption2.SelectedItem.ToString() == "제목")
                    query += "TITL";
                else if (bookOption2.SelectedItem.ToString() == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }
                query += "&operator=0";
            }
            else
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery1.Text) + "," + HttpUtility.UrlEncode(bookQuery2.Text);
                query += "&field=";

                if (bookOption1.SelectedItem.ToString() == "제목")
                    query += "TITL";
                else if (bookOption1.SelectedItem.ToString() == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }

                if (bookOption2.SelectedItem.ToString() == "제목")
                    query += ",TITL";
                else if (bookOption2.SelectedItem.ToString() == "저자")
                    query += ",AUTH";
                else
                {
                    query += ",PUBN";
                }

                query+="&operator=0,";

                if (bookOperator.SelectedItem.ToString() == "AND")
                {
                    query += "1";
                }
                else if (bookOperator.SelectedItem.ToString() == "OR")
                {
                    query += "2";
                }
                else
                {
                    query += "3";
                }
            }

            query += "&cntperpage=100&viewoption=1&sort=DEFAULT";

            bookQuery = query; // 최종 쿼리 넘겨줌
        }

        // 한쪽에서 옵션 고르면 다른 쪽에선 그 옵션 제거
        private void bookOption1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (bookOption2.SelectedItem != null)
            {
                if (bookOption2.SelectedItem.ToString() == comboBox.SelectedItem.ToString())
                {
                    MessageBox.Show("두 옵션이 같습니다 >:[", "Robot의 경고");
                }
            }
        }

        // 한쪽에서 옵션 고르면 다른 쪽에선 그 옵션 제거
        private void bookOption2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (bookOption1.SelectedItem != null)
            {
                if (bookOption1.SelectedItem.ToString() == comboBox.SelectedItem.ToString())
                {
                    MessageBox.Show("두 옵션이 같습니다 >:[", "Robot의 경고");
                }
            }
        }

        // 책 검색에서 엔터 입력
        private void bookQuery1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bookSearch_Click(sender, e);
            }
        }

        private void bookQuery2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bookSearch_Click(sender, e);
            }
        }

        // 책 클릭 시 책 사진 보여줌
        private void bookGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bookPic.Visible = false;
            bookReviewUrl = "";
            bookReview.Text = "...";

            DataGridView grid = (DataGridView)sender;
            //http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=9788996427513

            // 책 이미지 가져옴
            string url = books[grid.SelectedRows[0].Index].thumbnail;

            if (url != "")
            {
                bookPic.Load("http://library.unist.ac.kr/DLiWeb25/comp/search/thumb.axd?url=" + url.Split('=')[1]);
                bookPic.Visible = true;
            }

            string title = books[grid.SelectedRows[0].Index].title;

            if (title.Length > 30)
            {
                bookTitle.Text = title.ToString().Substring(0, 30) + "\r\n" + title.ToString().Substring(30);
            }
            else {
                bookTitle.Text = title.ToString();
            }

            // 도서 상태 확인 추가
            loadBookStat(books[grid.SelectedRows[0].Index].cid);

            isbn = books[grid.SelectedRows[0].Index].isbn;
        }

        // 키보드 이동할 때도 이미지 바뀜.
        private void bookGridView_SelectionChanged(object sender, EventArgs e)
        {
            bookPic.Visible = false;
            string url ="";
            bookReviewUrl = "";
            bookReview.Text = "...";

            DataGridView grid = (DataGridView)sender;
            //http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=9788996427513

            // 책 이미지 가져옴
            if (grid.RowCount == 0)
                return;

            if(grid.SelectedRows[0] !=null)
                url = books[grid.SelectedRows[0].Index].thumbnail;

            if (url != "")
            {
                bookPic.Load("http://library.unist.ac.kr/DLiWeb25/comp/search/thumb.axd?url=" + url.Split('=')[1]);
                bookPic.Visible = true;
            }

            string title = books[grid.SelectedRows[0].Index].title;

            if (title.Length > 30)
            {
                bookTitle.Text = title.ToString().Substring(0, 30) + "\r\n" + title.ToString().Substring(30);
            }
            else
            {
                bookTitle.Text = title.ToString();
            }

            // 도서 상태 추가
            loadBookStat(books[grid.SelectedRows[0].Index].cid);

            isbn= books[grid.SelectedRows[0].Index].isbn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bookReviewUrl == "")
            {
                MessageBox.Show("리뷰가 0건입니다 :-(", "Robot의 경고");
            }
            else
            {
                System.Diagnostics.Process.Start(bookReviewUrl);
            }
        }

        // 도서 상태 불러오기
        private void loadBookStat(string cid)
        {
            //http://library.unist.ac.kr/DLiWeb25Eng/comp/search/SearchHandler.aspx?action=stock&cid=357465
            browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/comp/search/SearchHandler.aspx?action=stock&cid="+cid);
            /*
            XmlDocument doc = new XmlDocument();
            doc.Load("http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=" + isbn);

            XmlNodeList elemList = doc.GetElementsByTagName("link");
            for (int i = 0; i < elemList.Count; i++)
            {
                browser.Navigate(elemList[i].InnerXml);
            }*/
        }

        private void studyGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (browser.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/studyroom/reserve.aspx?m_var=112&roomid=1&rdate=") != -1)
            {
                browser.Navigate("http://library.unist.ac.kr/dliweb25/studyroom/detail.aspx?m_var=112&roomid=" + (roomNumberBox.SelectedIndex + 1).ToString());
            }
            DataGridView grid = (DataGridView)sender;
            studyGroup.Enabled = true;

            string hour = grid.Columns[grid.SelectedCells[0].ColumnIndex].HeaderText.ToString();
            string date = grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString().Replace("-", "");

            doc.InvokeScript("fnReserve", new object[] { thisYear + date, hour });

            studyDateLabel.Text = thisYear + "년 " + date.Substring(0, 2) + "월 " + date.Substring(2) + "일 " + hour + "시 ~ ";
        }
    }
}
