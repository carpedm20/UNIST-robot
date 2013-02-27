
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace robot
{
    class BB
    {
        public BBBoard[] board;

        WebBrowser browser;
        HtmlDocument doc = null;

        public DevComponents.DotNetBar.SideBar[] bbsideBar;
        public DevComponents.DotNetBar.SideBarPanelItem[] bbsideItem;

        public BB(WebBrowser browser)
        {
            this.browser = browser;
            browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements");
        }

        public void setBoard()
        {
            doc = browser.Document as HtmlDocument;
            HtmlElementCollection options = doc.GetElementsByTagName("Option");

            int removeCount = 0;

            for (int i = 0; i < options.Count; i++)
            {
                if (options[i].InnerText.IndexOf("Survey") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("Open Study") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("Organizations") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("Show All") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("Institution Only") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("Courses Only") != -1)
                    removeCount++;
                else if (options[i].InnerText.IndexOf("UNIST") != -1)
                    removeCount++;
            }

            board = new BBBoard[options.Count - removeCount];

            int j = 0;

            for (int i = 0; i < options.Count; i++)
            {
                string n = options[i].InnerText.Replace("-", "");

                // Open Study 제외
                if (n.IndexOf("Open Study") != -1 || n.IndexOf("Organizations") != -1 || n.IndexOf("Survey") != -1 || n.IndexOf("Show All") != -1 || n.IndexOf("Institution Only") != -1 || n.IndexOf("Courses Only") != -1 || n.IndexOf("UNIST") != -1)
                {
                    j++;
                    continue;
                }

                board[i - j] = new BBBoard();
                board[i - j].url = options[i].OuterHtml.Split('=')[1].Split('>')[0];
                board[i - j].name = n;
            }
        }

        public void getCourceMenu()
        {
            // http://bb.unist.ac.kr/webapps/blackboard/content/courseMenu.jsp?course_id=_11194_1&newWindow=true&openInParentWindow=true&refreshCourseMenu=true

            for (int i = 0; i < board.Count(); i++)
            {
                string url = "http://bb.unist.ac.kr/webapps/blackboard/content/courseMenu.jsp?course_id=" + board[i].url;

                browser.Navigate(url);

                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                doc = browser.Document as HtmlDocument;
                HtmlElementCollection options = doc.GetElementsByTagName("Option");

                HtmlElement elements = ElementsByClass(doc, "courseMenu").ElementAt(0);
                HtmlElementCollection lists = elements.GetElementsByTagName("li");
                HtmlElementCollection a = elements.GetElementsByTagName("a");

                board[i].menu = new List<string>();
                board[i].menuUrl = new List<string>();

                for (int j = 0; j < lists.Count; j++)
                {
                    board[i].menu.Add(lists[j].InnerText);
                    board[i].menuUrl.Add(a[j].GetAttribute("href"));
                }
            }

            addCourseMenu();
        }

        public void addCourseMenu()
        {
            bbsideBar = new DevComponents.DotNetBar.SideBar[board.Count()];
            bbsideItem = new DevComponents.DotNetBar.SideBarPanelItem[board.Count()];

            for (int i = 0; i < board.Count(); i++)
            {
                bbsideBar[i] = new DevComponents.DotNetBar.SideBar();
                bbsideItem[i] = new DevComponents.DotNetBar.SideBarPanelItem();

                DevComponents.DotNetBar.ButtonItem[] bbSideButton = new DevComponents.DotNetBar.ButtonItem[board[i].menu.Count];

                for (int j = 0; j < board[i].menu.Count; j++)
                {
                    bbSideButton[j] = new DevComponents.DotNetBar.ButtonItem();
                    bbSideButton[j].ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                    bbSideButton[j].Name = "bbSideButton" + i.ToString() + j.ToString();
                    bbSideButton[j].Text = board[i].menu[j];
                    bbSideButton[j].Click += new System.EventHandler(board[i].bbSideItem_click);

                    bbsideItem[i].SubItems.Add(bbSideButton[j]);
                }

                bbsideItem[i].FontBold = true;
                bbsideItem[i].Name = "bbsideItem" + i.ToString();
                bbsideItem[i].Text = board[i].name;

                bbsideBar[i].Font = new Font("Malgun Gothic", 9);
                bbsideBar[i].AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
                bbsideBar[i].AllowUserCustomize = false;
                bbsideBar[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                bbsideBar[i].BorderStyle = DevComponents.DotNetBar.eBorderType.None;
                bbsideBar[i].ExpandedPanel = bbsideItem[i];
                bbsideBar[i].ForeColor = System.Drawing.Color.Black;
                bbsideBar[i].Location = new System.Drawing.Point(i * 123, 0);
                bbsideBar[i].Name = "bbsideBar" + i.ToString();
                bbsideBar[i].Panels.AddRange(new DevComponents.DotNetBar.BaseItem[] {
                    bbsideItem[i]});
                bbsideBar[i].ShowToolTips = false;
                bbsideBar[i].Size = new System.Drawing.Size(123, 171);
                bbsideBar[i].Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                bbsideBar[i].TabIndex = 9;
                bbsideBar[i].Text = "sideBar1";
                bbsideBar[i].UsingSystemColors = true;

                MainForm.bbpanel.Controls.Add(bbsideBar[i]);
            }
        }

        static IEnumerable<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    yield return e;
        }

        /*
        public string[] className;
        public string[] classUrl;
        public int classNum;

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        public BB(string cookie)
        {
            this.cookie = cookie;
            classNum = 0;

            getClassName();
        }

        private void getClassName()
        {
            string url = "http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements";
            wRes = getRespose(url);

            // http 내용 추출
            Stream respPostStream = wRes.GetResponseStream();
            StreamReader readerPost = new StreamReader(respPostStream, Encoding.Default);

            resResult = readerPost.ReadToEnd();

            doc = (IHTMLDocument2)new HTMLDocument();
            doc.clear();
            doc.write(resResult);
            doc.close();

            IHTMLElementCollection options = ((IHTMLDocument3)doc).getElementsByTagName("Option");
            classNum = options.length - 3;
            // bb 게시판 id
            className = new String[classNum];
            classUrl = new String[classNum];

            int j = 0;
            string n;

            for (int i = 3; i < classNum; i++)
            {
                n = ((IHTMLElement)options.item(i,0)).innerText.Replace("-", "");

                // Open Study 제외
                if (n.IndexOf("Open Study") != -1 || n.IndexOf("Organizations") != -1)
                {
                    j++;
                    classNum--;
                    continue;
                }

                classUrl[i - 3 - j] = ((IHTMLElement)options.item(i,0)).outerHTML.Split('=')[1].Split('>')[0];
                className[i - 3 - j] = n;

                // 리스트에 과목명 추가
                
                DevComponents.DotNetBar.ButtonItem butItem = new DevComponents.DotNetBar.ButtonItem();

                butItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
                butItem.CanCustomize = false;
                butItem.Name = "buttonItem1";
                butItem.Text = className[i - 3 - j];

                sideBlackBoard.SubItems.Add(butItem);
                
            }
        }

        private HttpWebResponse getRespose(String url)
        {
            uri = new Uri(url);
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "GET";
            wReq.CookieContainer = new CookieContainer();
            wReq.CookieContainer.SetCookies(uri, cookie);

            return (HttpWebResponse)wReq.GetResponse();
        }
        */
    }
}
