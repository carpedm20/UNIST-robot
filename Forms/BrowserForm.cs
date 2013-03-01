using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace robot.Forms
{
    public partial class BrowserForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        string cookie;
        int clickedTabIndex = 0;
        List<ExtendedWebBrowser> browsers;

        public BrowserForm(string url, string cookie)
        {
            InitializeComponent();

            this.Font = new Font(Program.myFonts.Families[0], 9);

            browser.Navigate(url);

            this.cookie = cookie;
            InitializeBrowserEvents(browser);

            tabControl.ContextMenuStrip = closeMenuStrip;

            browsers = new List<ExtendedWebBrowser>();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ExtendedWebBrowser web=(ExtendedWebBrowser)sender;

            if (web.Url.ToString().IndexOf("http://loginsvc.cyworld.com/ims/") != -1)
            {
                int s = tabControl.SelectedIndex;
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
                if (s != 0)
                {
                    tabControl.SelectedIndex = s - 1;
                }

                else
                {
                    tabControl.SelectedIndex = 0;
                }
            }

            if (web.CanGoBack)
            {
                backBtn.Enabled = true;
            }
            else
            {
                backBtn.Enabled = false;
            }
            if (web.CanGoForward)
            {
                nextBtn.Enabled = true;
            }
            else
            {
                nextBtn.Enabled = false;
            }

            browser.Document.Cookie = cookie;
            currentUrlLabel.Text = e.Url.ToString();

            ((TabPage)(web.Parent)).Text = web.DocumentTitle;
        }

        /*
        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            ExtendedWebBrowser web = (ExtendedWebBrowser)sender;

            if (e.Url.ToString().IndexOf("http://dorm.unist.ac.kr/home/popup/pop.asp?board_nm=dorm_notice") != -1)
            {
                e.Cancel = true;
            }
        }
        */

        private void cancel_newWindow(object sender, CancelEventArgs e)
        {
            if (((ExtendedWebBrowser)sender).Url.ToString().IndexOf("http://dorm.unist.ac.kr/home/index_01.asp") != -1)
                e.Cancel = true;
            if (((ExtendedWebBrowser)sender).Url.ToString() == "http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp")
                e.Cancel = true;

        }

        private void currentUrlLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
                ex.Navigate(currentUrlLabel.Text);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.GoForward();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.GoBack();
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void InitializeBrowserEvents(ExtendedWebBrowser SourceBrowser)
        {
            SourceBrowser.ScriptErrorsSuppressed = true;

            SourceBrowser.NewWindow += new CancelEventHandler(cancel_newWindow);
            SourceBrowser.NewWindow2 += new EventHandler<NewWindow2EventArgs>(SourceBrowser_NewWindow2);
            SourceBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            // SourceBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(browser_Navigating);
        }

        void SourceBrowser_NewWindow2(object sender, NewWindow2EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            /*
            if (((ExtendedWebBrowser)sender).Url.ToString().IndexOf("cyworld") != -1 || ((ExtendedWebBrowser)sender).Url.ToString().IndexOf("nate") != -1)
            {
                return;
            }
            */
            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            e.PPDisp = NewTabBrowser.Application;
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex;

            if (tabControl.TabPages.Count == 0)
            {
                this.Visible = false;
                return;
            }
            else
            {
                ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            }

            if (ex.Url == null)
                currentUrlLabel.Text = "";
            else
                currentUrlLabel.Text = ex.Url.ToString();

            if (ex.CanGoBack)
            {
                backBtn.Enabled = true;
            }
            else
            {
                backBtn.Enabled = false;
            }
            if (ex.CanGoForward)
            {
                nextBtn.Enabled = true;
            }
            else
            {
                nextBtn.Enabled = false;
            }
        }

        private void portalBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp");
        }

        private void epBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://portal.unist.ac.kr/EP/tmaxsso/runSAPEP.jsp");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp");
        }

        private void bbBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://bb.unist.ac.kr");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://bb.unist.ac.kr");
        }

        private void libraryBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://library.unist.ac.kr");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://library.unist.ac.kr");
        }

        private void mealBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate(MainForm.mealUrl);
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://dorm.unist.ac.kr");
        }

        private void dormBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://dorm.unist.ac.kr");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://dorm.unist.ac.kr");
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://mail.unist.ac.kr");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://mail.unist.ac.kr");
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("https://www.google.com/calendar/embed?src=anr9a4cbgv3os8ac5i8fg6fqic%40group.calendar.google.com&ctz=Asia/Seoul");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        private void nightMealBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("https://docs.google.com/spreadsheet/ccc?key=0AiTS2HBKYvZxdEpRVHJ1cXliQVRNUTI1OVQwTzlyTFE&usp=sharing#gid=0");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        private void nateClubBtn_Click(object sender, EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

            ExtendedWebBrowser NewTabBrowser = new ExtendedWebBrowser()
            {
                Parent = NewTabPage,
                Dock = DockStyle.Fill,
                Tag = NewTabPage
            };

            NewTabBrowser.Navigate("http://club.cyworld.com/ClubV1/Home.cy/53814181");
            // NewTabBrowser.Navigate("http://xo.nate.com/Notfound.sk?redirect=http://club.cyworld.com/uniallstar&cpurl=www_ndr.nate.com%2flogin&viewnid=null&viewcid=null&flag=Y&e_url=http://www.nate.com/&mode=");
            InitializeBrowserEvents(NewTabBrowser);

            tabControl.TabPages.Add(NewTabPage);
            tabControl.SelectedTab = NewTabPage;

            // ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            // ex.Navigate("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // iterate through all the tab pages
                for (int i = 0; i < tabControl.TabCount; i++)
                {
                    // get their rectangle area and check if it contains the mouse cursor
                    Rectangle r = tabControl.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        clickedTabIndex = i;
                    }
                }
            }
        }

        private void 닫기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            tabControl.TabPages.RemoveAt(clickedTabIndex);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Refresh();
        }

        private void tabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (clickedTabIndex == tabControl.SelectedIndex)
            {
                tabControl.SelectedIndex = tabControl.SelectedIndex - 1;
            }
        }
    }
}
