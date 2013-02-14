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
using CustomUIControls;
using System.Diagnostics;

// http://somerandomdude.com/work/iconic/

namespace robot
{
    public partial class MainForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        HtmlDocument doc = null;

        public static string userName = "";

        string bookReviewUrl = "";

        /****************************/
        static public bool isLoading = true;
        static public bool isExiting = false;

        Portal portal;
        int currentBoardId = 1;
        BB bb;
        Library library;

        static public string mailCookie = "";
        static public bool mailFormExist = false;

        static public bool alarmFormExist = false;

        static public bool settingFormExist = false;

        static public DataGridView gridView;
        static public WebBrowser brows;
        static public Panel bbpanel;

        static public string bbCookie = "";

        static public MailForm mailForm;
        static public SettingForm settingForm;
        static public AlarmForm alarmForm;

        static public bool alarmSet = false;

        static public System.Windows.Forms.Timer timer1;
        static public System.Windows.Forms.Timer timer2;

        Say say;
        static public System.Windows.Forms.Label saylabel;

        string selectedDate = "";
        string dateFormat = "00";

        string[] posibleDate = new string[4];

        Weather weather;
        /****************************/

        public MainForm()
        {
            InitializeComponent();

            visibleLoading();

            // 브라우저 스크립트 에러 무시
            browser.ScriptErrorsSuppressed = true;

            brows = this.browser;
            gridView = this.boardGrid;
            bbpanel = this.bbPanel;
            timer1 = this.notifyTimer;
            timer2 = this.sayTimer;
            saylabel = this.sayLabel;

            browser.Navigate("https://portal.unist.ac.kr/EP/web/login/unist_acube_login_int.jsp");

            // 책 검색 옵션 초기화
            bookOption1.SelectedIndex = 0;
            bookOption2.SelectedIndex = 1;
            bookOperator.SelectedIndex = 0;
            roomNumberBox.SelectedIndex = 0;

            circularProgress1.IsRunning = true;

            alarmForm = new AlarmForm();
            settingForm = new SettingForm();
            isLoading = true;
            autoLoginSetup();

            say = new Say();
            weather = new Weather();
            weatherTip.SetToolTip(weatherBox, weather.weather);

            sayLabel.Text = say.says.ElementAt(0).Key;
            sayToolTip.SetToolTip(sayLabel, say.says.ElementAt(0).Value);
            sayLabel.ContextMenuStrip = sayStrip;

            selectedDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString(dateFormat);
            studyDate.Text = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString(dateFormat);

            notifyTip.SetToolTip(notifyBox, "?");
            mailTip.SetToolTip(mailBox, "메일 보내기");
            settingTip.SetToolTip(settingBox, "설정");
        }

        private void autoLoginSetup()
        {
            if (Program.autoLogin == true)
            {
                settingForm.loginSwitch.Value = true;
            }
            else
            {
                settingForm.loginSwitch.Value = false;
            }
        }

        /**********************************************************
         * 
         *  게시판 boardGrid
         *  
         **********************************************************/

        private void showBoardGrid(int boardId)
        {
            while (boardGrid.Rows.Count != 0)
            {
                boardGrid.Rows.RemoveAt(0);
            }

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
             *  브라우저 오른쪽으로 이동
             *  
             **********************************************************/

            Point point = new Point(browser.Right, 0);
            browser.Document.Window.ScrollTo(point);
            
            if(isLoading==false && studyGrid.Visible != true)
                browser.Visible = true;

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

            if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/portal/frameset.jsp")
            {
                bb=new BB(browser);
            }

            else if (e.Url.ToString() == "http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements")
            {
                bb.setBoard();

                bb.getCourceMenu();
                
                DevComponents.DotNetBar.ButtonItem[] bblist = new DevComponents.DotNetBar.ButtonItem[bb.board.Count()];
                System.Windows.Forms.ToolStripMenuItem[] trayItem = new System.Windows.Forms.ToolStripMenuItem[bb.board.Count()];
                for (int i = 0; i < bb.board.Length; i++)
                {
                    if (bb.board[i] == null)
                        break;
                    bblist[i] = new DevComponents.DotNetBar.ButtonItem();
                    bblist[i].ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    bblist[i].CanCustomize = false;
                    bblist[i].Name = "buttonItem" + Convert.ToInt32(i);
                    bblist[i].Text = bb.board[i].name;
                    bblist[i].Click += new System.EventHandler(sideBBClick);
                    bblist[i].Click += new System.EventHandler(visibleBB);

                    sideBB.SubItems.Add(bblist[i]);

                    trayItem[i] = new System.Windows.Forms.ToolStripMenuItem();
                    trayItem[i].Name = "BBToolStripMenuItem"+i.ToString();
                    trayItem[i].Size = new System.Drawing.Size(152, 22);
                    trayItem[i].Text = bb.board[i].name;
                    trayItem[i].Click += new System.EventHandler(trayBBClick);
                    trayItem[i].Click += new System.EventHandler(visibleBB);
                    블랙보드ToolStripMenuItem.DropDownItems.Add(trayItem[i]);
                }
                
                browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/tmaxsso/first_cs.aspx");
            }

            /**********************************************************
             * 
             *  도서관
             *
             **********************************************************/

            if (e.Url.ToString().IndexOf("http://library.unist.ac.kr/DLiWeb25Eng/default.aspx") != -1)
            {
                library = new Library(browser.Document.Cookie);
                
                browser.Navigate("http://portal.unist.ac.kr/EP/web/security/jsp/SSO_unistMail.jsp");
            }

            /**********************************************************
             * 
             *  전자우편 - firstLoading 끝남
             *
             **********************************************************/

            if (e.Url.ToString().IndexOf("http://mail.unist.ac.kr/mail/mailList.crd") != -1)
            {
                circularProgress1.IsRunning = false;
                circularProgress1.Visible = false;

                mailBox.Visible = true;
                settingBox.Visible = true;
                weatherBox.Visible = true;
                notifyBox.Visible = true;

                System.Web.UI.WebControls.GridViewSelectEventArgs ee = new System.Web.UI.WebControls.GridViewSelectEventArgs(1);
                boardGrid_SelectionChanged(boardGrid, ee);

                buttonItem1_Click(null, ee);

                mailCookie = browser.Document.Cookie;

                visiblePortal();

                isLoading = false;
                visiblePortal();

                notifyTimer.Start();
                sayTimer.Start();
                sessionTimer.Start();

                mailForm = new MailForm(mailCookie);
            }
        }

        /**********************************************************
         * 
         *  boardSlide 에서 블랙보드 게시판 클릭시 이벤트 -> Announcement 보여줌
         *  
         **********************************************************/

        private void sideBBClick(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem butItem = (DevComponents.DotNetBar.ButtonItem)sender;

            for(int i=0; i<bb.board.Length; i++) {
                if (bb.board[i].name == butItem.Text)
                {
                    browser.Navigate(bb.board[i].menuUrl[1]);
                    return;
                }
            }
        }

        /**********************************************************
         * 
         *  tray 아이콘 에서 블랙보드 게시판 클릭시 이벤트 -> Announcement 보여줌
         *  
         **********************************************************/

        private void trayBBClick(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem butItem = (System.Windows.Forms.ToolStripMenuItem)sender;
            
            this.Visible = true;

            for (int i = 0; i < bb.board.Length; i++)
            {
                if (bb.board[i].name == butItem.Text)
                {
                    browser.Navigate(bb.board[i].menuUrl[1]);
                    return;
                }
            }
        }

        /**********************************************************
         * 
         *  설정
         *  
         **********************************************************/
        
        private void settingBox_Click(object sender, EventArgs e)
        {
            if (settingFormExist == true)
            {
                MessageBox.Show("창이 이미 열려 있습니다 :(", "Robot의 경고");
                return;
            }

            if (settingFormExist == false)
                settingFormExist = true;

            settingForm.Show();

            // MessageBox.Show("Designed by Kim Tae Hoon ಠ_ಠ");
        }

        /**********************************************************
         * 
         *  메일
         *  
         **********************************************************/

        private void mailBox_Click(object sender, EventArgs e)
        {
            if (mailFormExist == true)
            {
                MessageBox.Show("창이 이미 열려 있습니다 :(", "Robot의 경고");
                return;
            }

            if (mailFormExist == false)
                mailFormExist = true;


            if (mailCookie == "")
            {
                MessageBox.Show("메일 서버에 접속할 수 없습니다 -_-?", "Robot의 경고");
                return;
            }

            mailForm = new MailForm(mailCookie);
            mailForm.Show();
        }

        /**********************************************************
         * 
         *  스터디 룸
         *  
         **********************************************************/

        private void loadStudyRoomStat(string date)
        {
            circularProgress1.IsRunning = true;
            circularProgress1.Visible = true;

            nextMonthBtn.Enabled = false;
            previousMonthBtn.Enabled = false;
            roomNumberBox.Enabled = false;

            studyGroup.Enabled = false;

            if (roomNumberBox.SelectedIndex == 4)
            {
                studyStudentId6.Enabled = true;
                studyStudentId7.Enabled = true;
                studyStudentId8.Enabled = true;
            }

            else
            {
                studyStudentId6.Enabled = false;
                studyStudentId7.Enabled = false;
                studyStudentId8.Enabled = false;
            }

            library.loadStudyroomStatus(roomNumberBox.SelectedIndex + 1, date);

            while (studyGrid.Rows.Count != 0)
            {
                studyGrid.Rows.RemoveAt(0);
            }

            calculatePosibleDate(library.dayCount);

            // study room grid 내용 추가
            for (int i = 0; i < library.dayCount; i++)
            {
                studyGrid.Rows.Add(library.roomStat[i]);

                // 오늘 날짜 줄 표시
                for (int j = 0; j < 4; j++)
                {
                    if (studyDate.Text.Substring(0, 4) == posibleDate[j].Substring(0, 4)
                        && library.roomStat[i][0].Substring(0, 2) == posibleDate[j].Substring(4, 2)
                        && Convert.ToInt32(library.roomStat[i][0].Substring(3)) == Convert.ToInt32(posibleDate[j].Substring(6, 2)))
                    {
                        studyGrid.Rows[i].DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.PowderBlue };
                    }
                }                
            }

            nextMonthBtn.Enabled = true;
            previousMonthBtn.Enabled = true;
            roomNumberBox.Enabled = true;

            circularProgress1.IsRunning = false;
            circularProgress1.Visible = false;
        }

        /**********************************************************
         * 
         *  예약 버튼
         *  
         **********************************************************/

        private void studyReserveBtn_Click(object sender, EventArgs e)
        {
            doc = browser.Document as HtmlDocument;

            if (studyTimeBox.SelectedItem == null)
            {
                MessageBox.Show("사용할 시간을 선택해 주세요 :&", "Robot의 경고");
                return;
            }

            doc.GetElementById("ctl00_ContentPlaceHolder_ddusehour").SetAttribute("value", studyTimeBox.SelectedItem.ToString().Substring(0,1));

            if (studyStudentId1.Text != "")
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_1").SetAttribute("value", studyStudentId1.Text);
            if (studyStudentId2.Text != "")
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_2").SetAttribute("value", studyStudentId2.Text);
            if (studyStudentId3.Text != "")
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_3").SetAttribute("value", studyStudentId3.Text);
            if (studyStudentId4.Text != "")
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_4").SetAttribute("value", studyStudentId4.Text);
            if (studyStudentId5.Text != "" )
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_5").SetAttribute("value", studyStudentId5.Text);
            if (studyStudentId6.Text != "" && studyStudentId6.Enabled != false)
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_6").SetAttribute("value", studyStudentId6.Text);
            if (studyStudentId7.Text != "" && studyStudentId7.Enabled != false)
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_7").SetAttribute("value", studyStudentId7.Text);
            if (studyStudentId8.Text != "" && studyStudentId8.Enabled != false)
                doc.GetElementById("ctl00_ContentPlaceHolder_txtcompany_8").SetAttribute("value", studyStudentId8.Text);

            if (studyEtc.Text != "")
                doc.GetElementById("ctl00_ContentPlaceHolder_txtnote").SetAttribute("value", studyEtc.Text);
            
            mshtml.HTMLDocument hdoc = doc.DomDocument as mshtml.HTMLDocument;

            foreach (IHTMLElement hel in (mshtml.IHTMLElementCollection)hdoc.body.all)
            {
                if (hel.getAttribute("id", 0) != null)
                {
                    if (hel.getAttribute("id", 0).ToString().IndexOf("ctl00_ContentPlaceHolder_btnSubmit") != -1)
                    {
                        hel.click();
                    }
                }
            }
        }

        /**********************************************************
         * 
         *  스터디 룸 번호 변경시
         *  
         **********************************************************/

        private void roomNumberBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading == true)
                return;

            studyDate.Text = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString(dateFormat);

            loadStudyRoomStat(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString(dateFormat));
        }

        /**********************************************************
         * 
         *  스터디 룸 그리드 studyGrid 에 row 추가
         *  
         **********************************************************/

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
         *  스터디 룸 그리드 studyGrid 셀 클릭시
         *  
         **********************************************************/

        private void studyGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // http://library.unist.ac.kr/dliweb25eng/studyroom/reserve.aspx?m_var=112&roomid=1&rdate=20130214&rhour=10

            studyGroup.Enabled = false;
            DataGridView grid = (DataGridView)sender;

            string date = grid.Rows[grid.SelectedCells[0].RowIndex].Cells[0].Value.ToString().Replace("-", "");
            string hour = grid.Columns[grid.SelectedCells[0].ColumnIndex].HeaderText.ToString();

            if(hour=="Date") {
                MessageBox.Show("시간을 선택해 주세요 :^)", "Robot의 경고");
                return;
            }

            string url = "http://library.unist.ac.kr/dliweb25eng/studyroom/reserve.aspx?m_var=112&roomid=" + (roomNumberBox.SelectedIndex + 1).ToString()
                + "&rdate=" + studyDate.Text.Replace(".", "") + date.Substring(2) + "&rhour=" + hour;

            browser.Navigate(url);

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            if (browser.Document.Body.InnerText.IndexOf("일시적으로 서비스를 이용할 수 없습니다.") != -1)
            {
                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "-" && grid.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.PowderBlue)
                {
                    MessageBox.Show("이미 예약한 날입니다. :^)", "Robot의 경고");
                }

                else
                {
                    MessageBox.Show("올바른 시간을 선택해 주세요 :^)", "Robot의 경고");
                }
                return;
            }
            else
            {
                doc = browser.Document as HtmlDocument;
                IEnumerable<HtmlElement> elements = ElementsByClass(doc, "empty_trbg");

                HtmlElementCollection inputs = elements.ElementAt(6).GetElementsByTagName("input");

                studyPhoneNumber.Text = inputs[0].GetAttribute("value");
                studyEmail.Text = inputs[1].GetAttribute("value");

                studyDateLabel.Text = DateTime.Now.Year.ToString() + "년 " + date.Substring(0, 2) + "월 " + date.Substring(2) + "일 " + hour + "시";
                studyGroup.Enabled = true;

                if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString() == "R")
                {
                    studyTimeBox.Items.Clear();
                    studyTimeBox.Items.AddRange(new object[] {
                    "1 시간"});
                }
                else if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString() == "R")
                {
                    studyTimeBox.Items.Clear();
                    studyTimeBox.Items.AddRange(new object[] {
                    "1 시간",
                    "2 시간"});
                }
                else
                {
                    studyTimeBox.Items.Clear();
                    studyTimeBox.Items.AddRange(new object[] {
                    "1 시간",
                    "2 시간",
                    "3 시간"});
                }
            }
        }

        private void nextMonthBtn_Click(object sender, EventArgs e)
        {
            loadStudyRoomStat(getNextMonth());
        }

        private void previousMonthBtn_Click(object sender, EventArgs e)
        {
            loadStudyRoomStat(getPreviousMonth());
        }

        private string getNextMonth()
        {
            string str = studyDate.Text;
            int year = Convert.ToInt32(studyDate.Text.Substring(0, 4));
            int month = Convert.ToInt32(studyDate.Text.Substring(5));

            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }

            studyDate.Text = year.ToString() + "." + month.ToString(dateFormat);

            return year.ToString()+month.ToString(dateFormat);
        }

        private string getPreviousMonth()
        {
            string str = studyDate.Text;
            int year = Convert.ToInt32(studyDate.Text.Substring(0, 4));
            int month = Convert.ToInt32(studyDate.Text.Substring(5));

            if (month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            studyDate.Text = year.ToString() + "." + month.ToString(dateFormat);

            return year.ToString() + month.ToString(dateFormat);
        }

        /**********************************************************
         * 
         *  예약 가능한 날짜 계산, posibleDate 는 20130214 형태로 저장
         *  
         **********************************************************/

        private void calculatePosibleDate(int maxDate) {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int day = DateTime.Today.Day;

            if (maxDate - 1 < day + 3)
            {
                int overCount = day + 3 - (maxDate - 1);

                for (int i = 0; i < 3 - overCount; i++)
                {
                    posibleDate[i] = year.ToString() + month.ToString(dateFormat) + (day + i).ToString(dateFormat);
                }

                if (month == 12)
                {
                    for (int i = 4 - overCount; i < 4; i++)
                    {
                        posibleDate[i] = (year + 1).ToString() + "1" + (i - 4 + overCount + 1).ToString(dateFormat);
                    }
                }
                else
                {
                    for (int i = 4 - overCount; i < 4; i++)
                    {
                        posibleDate[i] = year.ToString() + (month + 1).ToString(dateFormat) + (i - 4 + overCount + 1).ToString(dateFormat);
                    }
                }
            }
            else
            {
                posibleDate[0] = year.ToString() + month.ToString(dateFormat) + day.ToString(dateFormat);
                posibleDate[1] = year.ToString() + month.ToString(dateFormat) + (day + 1).ToString(dateFormat);
                posibleDate[2] = year.ToString() + month.ToString(dateFormat) + (day + 2).ToString(dateFormat);
                posibleDate[3] = year.ToString() + month.ToString(dateFormat) + (day + 3).ToString(dateFormat);
            }
        }

        /**********************************************************
         * 
         *  책 검색
         *  
         **********************************************************/

        private void bookSearchBtn_Click(object sender, EventArgs e)
        {
            circularProgress1.Visible = true;
            circularProgress1.IsRunning = true;

            bookSearchBtn.Enabled = false;

            // 도서 상태 초기화
            while (bookGridView.Rows.Count != 0)
            {
                bookGridView.Rows.RemoveAt(0);
            }

            bookTitle.Text = "책 제목";
            bookReview.Text = "";
            bookReviewUrl = "";

            library.bookSearch(bookQuery1.Text, bookQuery2.Text, bookOption1.Text, bookOption2.Text, bookOperator.Text);

            if (library.books.Length == 0)
            {
                MessageBox.Show("조건에 맞는 책이 없습니다 :(", "Robot의 경고");
            }

            for (int i = 0; i < library.books.Length; i++)
            {
                bookGridView.Rows.Add(library.books[i].rows);
            }

            System.Web.UI.WebControls.GridViewSelectEventArgs ee = new System.Web.UI.WebControls.GridViewSelectEventArgs(1);
            bookGridView_SelectionChanged(boardGrid, ee);

            bookSearchBtn.Enabled = true;

            circularProgress1.Visible = false;
            circularProgress1.IsRunning = false;
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
                bookSearchBtn_Click(sender, e);
            }
        }

        private void bookQuery2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bookSearchBtn_Click(sender, e);
            }
        }

        /**********************************************************
         * 
         *  bookGridView 에서 select
         *  
         **********************************************************/
        
        private void bookGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (library.books == null)
                return;

            if (bookGridView.SelectedRows.Count == 0)
                return;

            bookThumnailRefresh();

            loadBookStat(library.books[bookGridView.SelectedRows[0].Index].cid);
            loadBookReview(library.books[bookGridView.SelectedRows[0].Index].isbn);
        }

        private void bookThumnailRefresh() 
        {
            bookPic.Visible = false;
            bookReviewUrl = "";
            bookReview.Text = "...";

            if (bookGridView.SelectedRows.Count == 0)
                return;

            string url=library.books[bookGridView.SelectedRows[0].Index].thumbnail;

            if (url != "")
            {
                bookPic.Load("http://library.unist.ac.kr/DLiWeb25/comp/search/thumb.axd?url=" + url.Split('=')[1]);
                bookPic.Visible = true;
            }

            Book book = library.books[bookGridView.SelectedRows[0].Index];

            if (book.title.Length > 30)
            {
                bookTitle.Text = book.title.ToString().Substring(0, 30) + "\r\n" + book.title.ToString().Substring(30);
            }
            else {
                bookTitle.Text = book.title.ToString();
            }

            bookInfo.Text = book.author + " | " + book.publisher + " | " + book.publishYear + " | " + book.kind;

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
            bookReviewUrl = "";
            bookReview.Text = "...";
            reviewStar.Visible = false;

            string url = library.loadBookReview(isbn);

            reviewBrowser.Navigate(url);
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
                MessageBox.Show("리뷰가 없습니다 :-(", "Robot의 경고");
            }
            else
            {
                System.Diagnostics.Process.Start(bookReviewUrl);
            }
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

        // library 스터디룸 예약
        private void buttonItem6_Click(object sender, EventArgs e)
        {
            loadStudyRoomStat(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString(dateFormat));
            visibleStudyroomReserve();
        }

        // 열람실 좌석 현황
        private void buttonItem7_Click(object sender, EventArgs e)
        {
            visiblePortal();

            browser.Navigate("http://seat.unist.ac.kr/EZ5500/RoomStatus/room_status.asp");

            boardGrid.Visible = false;
        }

        /**********************************************************
         * 
         *  리스트 별 visible 세팅
         *  
         **********************************************************/

        private void visibleLoading()
        {
            boardSlide.Visible = false;
            browser.Visible = false;
            boardGrid.Visible = false;
            bbPanel.Visible = false;
            studyGroup.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
            studyDate.Visible = false;
            nextMonthBtn.Visible = false;
            previousMonthBtn.Visible = false;
        }

        private void visiblePortal()
        {
            boardSlide.Visible = true;
            browser.Visible = true;
            boardGrid.Visible = true;

            bbPanel.Visible = false;
            studyGroup.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
            studyDate.Visible = false;
            nextMonthBtn.Visible = false;
            previousMonthBtn.Visible = false;
        }

        private void visibleBB(object sender, EventArgs e)
        {
            visibleBB();
        }

        public void visibleBB()
        {
            boardSlide.Visible = true;
            browser.Visible = true;
            bbPanel.Visible = true;

            boardGrid.Visible = false;
            studyGroup.Visible = false;
            bookGroup.Visible = false;
            bookInfoGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
            studyDate.Visible = false;
            nextMonthBtn.Visible = false;
            previousMonthBtn.Visible = false;
        }

        private void visibleBookSearch()
        {
            boardSlide.Visible = true;
            bookGroup.Visible = true;
            bookInfoGroup.Visible = true;

            bbPanel.Visible = false;
            browser.Visible = false;
            boardGrid.Visible = false;
            studyGroup.Visible = false;
            studyGrid.Visible = false;
            roomNumberLabel.Visible = false;
            roomNumberBox.Visible = false;
            studyDate.Visible = false;
            nextMonthBtn.Visible = false;
            previousMonthBtn.Visible = false;
        }

        private void visibleStudyroomReserve()
        {
            boardSlide.Visible = true;
            studyGrid.Visible = true;
            roomNumberLabel.Visible = true;
            roomNumberBox.Visible = true;
            studyGroup.Visible = true;
            studyDate.Visible = true;
            nextMonthBtn.Visible = true;
            previousMonthBtn.Visible = true;

            bbPanel.Visible = false;
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

        /**********************************************************
         * 
         *  네이버 리뷰 점수, reviewBrowser 사용
         *  
         **********************************************************/

        private void reviewBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("http://book.naver.com/bookdb/book_detail.nhn?bid=") != -1)
            {
                doc = reviewBrowser.Document as HtmlDocument;

                bookReview.Text = "";
                string html = reviewBrowser.Document.Body.InnerHtml;
                bookReviewUrl = "";

                HtmlElement element = ElementsByClass(doc, "txt_desc").ElementAt(0);

                string str = element.GetElementsByTagName("strong")[0].InnerText;
                bookReview.Text += str.Substring(0, str.IndexOf('.'));
                bookReview.Text += str.Substring(str.IndexOf('.'), 2);
                //bookReview.Text += html.Substring(html.IndexOf("네티즌리뷰")).Split('건')[0];
                bookReview.Text += " (" + element.InnerText.Split('|')[1].Substring(6) + ")";
                bookReviewUrl = element.GetElementsByTagName("a")[0].GetAttribute("href");

                reviewStar.Visible = true;
                reviewStar.Rating = (int)(Convert.ToDouble(element.GetElementsByTagName("strong")[0].InnerText) / 2);
            }
        }

        static IEnumerable<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    yield return e;
        }

        /**********************************************************
         * 
         *  RGB string 을 Color 객체로 변환
         *  
         **********************************************************/

        private Color ConvertColor_PhotoShopStyle_toRGB(string photoShopColor)
        {
            int red, green, blue;
            red = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(1, 2), 16));
            green = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(3, 2), 16));
            blue = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(5, 2), 16));

            return Color.FromArgb(red, green, blue);
        }

        /**********************************************************
         * 
         *  알림 타이머
         *  
         **********************************************************/

        private void notifyTimer_Tick(object sender, EventArgs e)
        {
            if (isLoading == true)
                return;
            else
                portal.checkNewLastestBoard();
        }

        /**********************************************************
         * 
         *  메인폼 로드시 트레이 아이콘의 ContextMenuStrip 연결
         *  
         **********************************************************/

        private void MainForm_Load(object sender, EventArgs e)
        {
            trayIcon.ContextMenuStrip = trayMenuStrip;
        }

        /**********************************************************
         * 
         *  닫기 버튼 이벤트 취소
         *  
         **********************************************************/

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExiting != true)
            {
                e.Cancel = true;

                this.Visible = false;
            }
        }

        /**********************************************************
         * 
         *  트레이 아이콘 관련 함수
         *  
         **********************************************************/

        private void 보이기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.보이기ToolStripMenuItem.Text == "감추기")
                this.Visible = false;
            else
                this.Visible = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyTimer.Stop();

            isExiting = true;

            Application.Exit();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        /**********************************************************
         * 
         *  시작 프로그램 등록 함수
         *  
         **********************************************************/

        static public void SetStartup(string AppName, bool enable)
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            Microsoft.Win32.RegistryKey startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey);

            if (enable)
            {
                if (startupKey.GetValue(AppName) == null)
                {
                    // 시작프로그램에 등록(Add startup reg key)
                    startupKey.Close();
                    startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                    startupKey.SetValue(AppName, Application.ExecutablePath.ToString());
                    startupKey.Close();
                }
            }
            else
            {
                // 시작프로그램에서 삭제(remove startup)
                startupKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(runKey, true);
                startupKey.DeleteValue(AppName, false);
                startupKey.Close();
            }
        }

        /**********************************************************
         * 
         *  브라우저 이동 직전에 visible 를 false로 바꿈
         *  
         **********************************************************/

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            browser.Visible = false;
        }

        /**********************************************************
         * 
         *  포탈 바로가기
         *  
         **********************************************************/

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://portal.unist.ac.kr");
        }

        /**********************************************************
         * 
         *  네이트 총재클럽 바로가기
         *  
         **********************************************************/

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        /**********************************************************
         * 
         *  랜덤 명언 timer
         *  
         **********************************************************/

        private void randomSayLabel() {
            Random r = new Random();
            int rand = r.Next(0, say.says.Count - 1);

            sayLabel.Text = say.says.ElementAt(rand).Key;
            sayToolTip.SetToolTip(sayLabel, say.says.ElementAt(rand).Value);
        }

        private void sayTimer_Tick(object sender, EventArgs e)
        {
            randomSayLabel();
        }

        private void 숨기기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settingForm.sayswitch.Value == true)
            {
                settingForm.sayswitch.Value = false;
                sayLabel.Visible = false;
                sayTimer.Stop();
            }
        }

        private void sayLabel_Click(object sender, EventArgs e)
        {
            randomSayLabel();
        }

        /**********************************************************
         * 
         *  트레이 아이콘 메뉴 opening event
         *  
         **********************************************************/

        private void trayMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.Visible == false)
            {
                this.보이기ToolStripMenuItem.Text = "보이기";
            }

            else
            {
                this.보이기ToolStripMenuItem.Text = "감추기";
            }
        }

        /**********************************************************
         * 
         *  웹브라우저 세션 유지 위해
         *  
         **********************************************************/

        private void sessionTimer_Tick(object sender, EventArgs e)
        {
            visibleLoading();

            isLoading = true;

            circularProgress1.IsRunning = true;
            circularProgress1.Visible = true;

            sayTimer.Stop();
            sayLabel.Text = "= 세션 유지를 위한 로딩이 진행 중입니다. 잠시만 기다려 주세요 :-) =";

            browser.Navigate("http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=B200902281833482321051");

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            browser.Navigate("http://portal.unist.ac.kr/EP/tmaxsso/runUEE.jsp?host=bb");

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            browser.Navigate("http://library.unist.ac.kr/DLiWeb25Eng/tmaxsso/first_cs.aspx");

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            browser.Navigate("http://portal.unist.ac.kr/EP/web/security/jsp/SSO_unistMail.jsp");

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            isLoading = false;

            sayTimer.Start();
            randomSayLabel();

            circularProgress1.IsRunning = false;
            circularProgress1.Visible = false;
        }

        /**********************************************************
         * 
         *  날씨 툴 팁
         *  
         **********************************************************/

        private void weatherTip_Popup(object sender, PopupEventArgs e)
        {
            weather.getWeather();
        }

        private void weatherBox_Click(object sender, EventArgs e)
        {
            weatherTip.SetToolTip(sender as Control, weather.weather);
        }

        private void 학사공지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            buttonItem1_Click(sender, e);
        }

        private void 전체공지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            buttonItem2_Click(sender, e);
        }

        private void 대학원공지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            buttonItem3_Click(sender, e);
        }

        private void 최신게시물ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            buttonItem4_Click(sender, e);
        }

        private void 도서검색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            visibleBookSearch();
        }

        private void 스터디룸예약ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            loadStudyRoomStat(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString(dateFormat));
            visibleStudyroomReserve();
        }

        private void 열람실좌석현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;

            visiblePortal();

            browser.Navigate("http://seat.unist.ac.kr/EZ5500/RoomStatus/room_status.asp");

            boardGrid.Visible = false;
        }

        private void 포탈홈페이지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://portal.unist.ac.kr");
        }

        private void 네이트총재클럽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        private void notifyBox_Click(object sender, EventArgs e)
        {
            if (alarmFormExist == true)
            {
                MessageBox.Show("창이 이미 열려 있습니다 :(", "Robot의 경고");
                return;
            }

            if (alarmFormExist == false)
                alarmFormExist = true;

            alarmForm.Show();
        }
    }
}
