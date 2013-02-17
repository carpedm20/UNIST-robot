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
        int currentTabIndex = 0;
        List<ExtendedWebBrowser> browsers;

        public BrowserForm(string url, string cookie)
        {
            InitializeComponent();

            browser.Navigate(url);

            this.cookie = cookie;
            InitializeBrowserEvents(browser);

            browsers = new List<ExtendedWebBrowser>();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ExtendedWebBrowser web=(ExtendedWebBrowser)sender;

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

        private void browser_NewWindow(object sender, CancelEventArgs e)
        {
            // e.Cancel = true;
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

            SourceBrowser.NewWindow2 += new EventHandler<NewWindow2EventArgs>(SourceBrowser_NewWindow2);
            SourceBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }

        void SourceBrowser_NewWindow2(object sender, NewWindow2EventArgs e)
        {
            TabPage NewTabPage = new TabPage();

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
            TabControl tab=(TabControl)sender;
            currentTabIndex = tab.SelectedIndex;
        }

        private void portalBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://portal.unist.ac.kr/EP/web/portal/jsp/EP_Default1.jsp");
        }

        private void bbBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://bb.unist.ac.kr");
        }

        private void libraryBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://library.unist.ac.kr");
        }

        private void dormBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://dorm.unist.ac.kr");
        }

        private void mailBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://mail.unist.ac.kr");
        }

        private void nateClubBtn_Click(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);
            ex.Navigate("http://club.cyworld.com/ClubV1/Home.cy/53814181");
        }

        private void tabControl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ExtendedWebBrowser ex = (ExtendedWebBrowser)(tabControl.SelectedTab.Controls[0]);

            if (ex.Url == null)
                currentUrlLabel.Text="";
            else
                currentUrlLabel.Text = ex.Url.ToString();
        }
    }
}
