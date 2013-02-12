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

namespace robot
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        HtmlDocument doc = null;

        string userName = "";

        int iconCount = 0; // welcomeLabel 이모티콘 모양

        string bookQuery = ""; // 책 검색 쿼리
        string bookReviewUrl = "";
        string isbn = ""; // 책 평점을 위한 변수

        string phoneNum = ""; // 스터디룸 예약을 위한 변수
        string email = ""; // 스터디룸 예약을 위한 변수
        string thisYear = "2013";

        Random r = new Random();

        /****************************/
        Portal portal;
        int currentBoardId = 1;
        BB bb;
        Library library;

        static public DataGridView gridView;
        static public WebBrowser brows;
        /****************************/

        public Form1()
        {

            InitializeComponent();

            // 브라우저 스크립트 에러 무시
            browser.ScriptErrorsSuppressed = true;

            brows = this.browser;
            gridView = this.boardGrid;

            autoLoginSetup();

            browser.Navigate("https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp");

            // 책 검색 옵션 초기화
            bookOption1.SelectedIndex = 0;
            bookOption2.SelectedIndex = 1;
            bookOperator.SelectedIndex = 0;
        }

        /**********************************************************
         * 
         *  자동 로그인 체크 박스
         *  
         **********************************************************/

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked == true)
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

        private void showBoardGrid(int boardId)
        {
            boardGrid.Enabled = false;

            while (boardGrid.Rows.Count != 0)
            {
                boardGrid.Rows.RemoveAt(0);
            }

            boardGrid.Enabled = true;

            portal.setBoard(boardId);
            currentBoardId = boardId;
            PortalBoard[] boards=portal.getBoard(boardId);
            int i = 0;

            if (boardId == 4)
            {
                this.Column5.Width = 0;
            }

            else
            {
                this.Column5.Width = 33;
            }

            foreach (PortalBoard b in boards)
            {
                if (boardId == 4)
                {
                    if (b.rows == null)
                        break;
                    boardGrid.Rows.Add(b.rows);
                    continue;
                }

                else
                {
                    boardGrid.Rows.Add(b.rows);

                    // 셀 글자 색 추가
                    if (b.color != Color.Black)
                    {
                        // 글자 볼드 추가
                        if (b.bold == true)
                        {
                            boardGrid.Rows[i].Cells[1].Style = new DataGridViewCellStyle
                            {
                                ForeColor = b.color,
                                Font = new Font(boardGrid.DefaultCellStyle.Font, FontStyle.Bold)
                            };
                        }
                        else
                        {
                            boardGrid.Rows[i].Cells[1].Style = new DataGridViewCellStyle { ForeColor = b.color };
                        }
                    }

                    // 글자 볼드 추가
                    if (b.bold == true)
                    {
                        boardGrid.Rows[i].Cells[1].Style.Font = new Font(boardGrid.DefaultCellStyle.Font, FontStyle.Bold);
                    }

                    i++;
                }
            }

            browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid="
                + portal.getBoardId(currentBoardId) + "&bullid=" + portal.getBoardbullId(currentBoardId, 0));

            boardGrid.Enabled = true;
            browser.Visible = true;
        }

        private void boardGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;

            if (grid.SelectedRows.Count == 0)
                return;

            if (currentBoardId == 4)
            {
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid="
                   + portal.getBoardId(currentBoardId, grid.SelectedRows[0].Index) + "&bullid=" + portal.getBoardbullId(currentBoardId, grid.SelectedRows[0].Index));
            }
            else
            {
                browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid="
                    + portal.getBoardId(currentBoardId) + "&bullid=" + portal.getBoardbullId(currentBoardId, grid.SelectedRows[0].Index));
            }
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /**********************************************************
             * 
             *  첫 로그인, 이름 저장, 학사 공지로 이동
             *  
             **********************************************************/

            if (e.Url.ToString() == "http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp") {
                userName=browser.DocumentTitle.ToString().Split('-')[1].Split('/')[0];
                welcomeLabel.Text = userName + " 님 환영합니다 :-)";

                portal = new Portal(browser.Document.Cookie);
                showBoardGrid(1);

                browser.Navigate("http://portal.unist.ac.kr/EP/tmaxsso/runUEE.jsp?host=bb");
            }

            /**********************************************************
             * 
             *  로그인 창에서 변수 입력
             *  
             **********************************************************/

            if (e.Url.ToString() == "https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp")
            {
                doc = browser.Document as HtmlDocument;

                doc.GetElementById("id").SetAttribute("value", Program.id);
                doc.GetElementsByTagName("input")["UserPassWord"].SetAttribute("value", Program.password);
                doc.InvokeScript("doLogin");
            }

            /**********************************************************
             * 
             *  블랙보드
             *
             **********************************************************/

            if (e.Url.ToString().IndexOf("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=") != -1)
            {
                browser.Visible = true;
            }

            if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/portal/frameset.jsp")
            {
                bb=new BB(browser);
            }

            else if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements")
            {
                bb.setBoard();

                DevComponents.DotNetBar.ButtonItem[] bblist = new DevComponents.DotNetBar.ButtonItem[bb.board.Count()];

                for (int i = 0; i < bb.board.Length; i++)
                {
                    if (bb.board[i] == null)
                        break;
                    bblist[i] = new DevComponents.DotNetBar.ButtonItem();
                    bblist[i].ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    bblist[i].CanCustomize = false;
                    bblist[i].Name = "buttonItem" + Convert.ToInt32(i);
                    bblist[i].Text = bb.board[i].name;
                    bblist[i].Click += new System.EventHandler(bb.board[i].bbboard_click);

                    slideBB.SubItems.Add(bblist[i]);
                }

                browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/tmaxsso/first_cs.aspx ");
            }

            // 스터디룸 예약
            /*if (e.Url.ToString().IndexOf("library.unist.ac.kr/dliweb25eng/studyroom/detail.aspx?") != -1)
            {
                HtmlElement table = doc.GetElementsByTagName("table")[1];

                /*browser.DocumentText = "<html>\r\n<style type=\"text/css\">\r\nbody { font-family:'Arial'; }\r\n.font-test { font:bold 24pt 'Arial'; }\r\n</style>" + 
                    //http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoA.gif
                    //table.OuterHtml.ToString().Replace("/DLiWeb25Eng/html/images/ico/icoA.gif", "http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoA.gif").Replace("DLiWeb25Eng/html/images/ico/icoN.gif", "http://library.unist.ac.kr/DLiWeb25Eng/html/images/ico/icoN.gif")
                    table.OuterHtml.ToString().Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoA.gif\" alert=\"Expire\">", "E").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoN.gif\" alert=\"Reserved\">", "R").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoU.gif\" alert=\"Commit\">", "E")
                    + "\r\n</html>";*/
                //string parsing = table.OuterHtml.ToString().Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoA.gif\" alert=\"Expire\">", "E").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoN.gif\" alert=\"Reserved\">", "R").Replace("<IMG src=\"/DLiWeb25Eng/html/images/ico/icoU.gif\" alert=\"Commit\">", "E");
                /*
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
            // 스터디 날짜 선택 시 이벤트
            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/studyroom/reserve.aspx?m_var=112&roomid=1&rdate=") != -1)
            {
                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "empty_trbg");
                HtmlElement info = elements.ElementAt(6);

                studyPhoneNumber.Text = phoneNum = info.GetElementsByTagName("input")[0].GetAttribute("value");
                studyEmail.Text = email = info.GetElementsByTagName("input")[1].GetAttribute("value");
            }*/
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

        /**********************************************************
         * 
         *  설정
         *  
         **********************************************************/

        private void settingLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Designed by Kim Tae Hoon ಠ_ಠ");
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

        /**********************************************************
         * 
         *  책 검색
         *  
         **********************************************************/

        private void bookSearch_Click(object sender, EventArgs e)
        {
            library = new Library(browser.Document.Cookie);

            // 도서 상태 초기화
            while (bookGridView.Rows.Count != 0)
            {
                bookGridView.Rows.RemoveAt(0);
            }

            bookTitle.Text = "책 제목";
            bookReview.Text = "";
            bookReviewUrl = "";

            

            library.bookSearch(bookQuery1.Text, bookQuery2.Text, bookOption1.Text, bookOption2.Text, bookOperator.Text);

            for (int i = 0; i < library.books.Length; i++)
            {
                bookGridView.Rows.Add(library.books[i].rows);
            }
        }

        /**********************************************************
         * 
         *  책 검색 옵션, 한쪽 고르면 다른 쪽에서 그 옵션 제거
         *  
         **********************************************************/

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

        /**********************************************************
         * 
         *  책 검색에서 엔터키 입력
         *  
         **********************************************************/

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

        /**********************************************************
         * 
         *  bookGridView 에서 row 클릭 시
         *  
         **********************************************************/
        
        private void bookGridView_SelectionChanged(object sender, EventArgs e)
        {
            bookThumnailRefresh();

            loadBookStat(library.books[bookGridView.SelectedRows[0].Index].cid);
            //loadBookReview(library.books[bookGridView.SelectedRows[0].Index].isbn);
        }

        private void bookThumnailRefresh() 
        {
            bookPic.Visible = false;
            bookReviewUrl = "";
            bookReview.Text = "...";

            string url=library.books[bookGridView.SelectedRows[0].Index].thumbnail;

            if (url != "")
            {
                bookPic.Load("http://library.unist.ac.kr/DLiWeb25/comp/search/thumb.axd?url=" + url.Split('=')[1]);
                bookPic.Visible = true;
            }

            string title = library.books[bookGridView.SelectedRows[0].Index].title;

            if (title.Length > 30)
            {
                bookTitle.Text = title.ToString().Substring(0, 30) + "\r\n" + title.ToString().Substring(30);
            }
            else {
                bookTitle.Text = title.ToString();
            }

            isbn = library.books[bookGridView.SelectedRows[0].Index].isbn;

            //http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=9788996427513
        }
        
        private void loadBookStat(string cid)
        {
            while (bookListGrid.Rows.Count != 0)
            {
                bookListGrid.Rows.RemoveAt(0);
            }

            Column37.Width = 80;

            string[] str = library.loadBookStat(cid);
            int count = str.Length / 4;

            for (int i = 0; i < count; i++)
            {
                string[] subStr=new string[4];

                Array.Copy(str, i * 4, subStr, 0, 4);
                bookListGrid.Rows.Add(subStr);

                if (subStr[0].IndexOf("대출중") != -1)
                {
                    Column37.Width = subStr[0].Length * 8;
                }
            }
        }

        private void loadBookReview(string isbn) 
        {
            bookReview.Text = "평점 : ";
            bookReviewUrl="";

            string[] str = library.loadBookReview(isbn);

            bookReview.Text = str[0];
            bookReviewUrl = str[1];
        }

        /**********************************************************
         * 
         *  책 리뷰 보기 클릭
         *  
         **********************************************************/

        private void bookReviewBtn_Click(object sender, EventArgs e)
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

        /**********************************************************
         * 
         *  리스트 클릭 이벤트 함수
         *  
         **********************************************************/

        // 학사 공지
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            visiblePortal();
            showBoardGrid(1);
        }

        // 전체 공지
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            visiblePortal();
            showBoardGrid(2);
        }

        // 대학원 공지
        private void buttonItem3_Click(object sender, EventArgs e)
        {
            visiblePortal();
            showBoardGrid(3);
        }

        // 최신 게시글
        private void buttonItem4_Click(object sender, EventArgs e)
        {
            visiblePortal();
            showBoardGrid(4);
        }

        // 도서 검색
        private void buttonItem5_Click(object sender, EventArgs e)
        {
            visibleBookSearch();
        }

        // 스터디룸 예약
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            visibleStudyroomReserve();
        }

        // 열람실 좌석 현황
        private void buttonItem7_Click(object sender, EventArgs e)
        {

        }

        /**********************************************************
         * 
         *  리스트 별 visible 세팅
         *  
         **********************************************************/

        private void visiblePortal()
        {
            browser.Visible = false;
            boardGrid.Visible = true;

            studyGroup.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
        }

        public void visibleBB()
        {
            browser.Visible = true;

            boardGrid.Visible = false;
            studyGroup.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
        }

        private void visibleBookSearch()
        {
            bookGroup.Visible = true;
            bookInfoGroup.Visible = true;

            browser.Visible = false;
            boardGrid.Visible = false;
            studyGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
        }

        private void visibleStudyroomReserve()
        {
            studyGrid.Visible = true;
            roomNumberLabel.Visible = true;
            roomNumberBox.Visible = true;
            studyGroup.Visible = true;

            browser.Visible = false;
            boardGrid.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
        }

        /**********************************************************
         * 
         *  브라우저 팝업창 disable
         *  
         **********************************************************/

        private void browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
