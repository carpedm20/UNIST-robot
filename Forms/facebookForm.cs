using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace robot
{
    public partial class FacebookForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        string url="";

        public FacebookForm()
        {
            InitializeComponent();

            browser.ScriptErrorsSuppressed = true; // 자바 스크립트 에러 무시

            browser.Navigate("http://touch.facebook.com");
        }

        private void FacebookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.isExiting == false)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            loginBtn.Enabled = false;

            browser.Navigate("http://touch.facebook.com");
        }

        private void FacebookForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.TopMost = TopMost;
                MainForm.facebookClick.Visible = true;
            }
            else
            {
                MainForm.facebookClick.Visible = false;
            }
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (url != browser.Url.ToString())
            {
                if(e.Url.ToString().IndexOf("side-area") == -1)
                    browser.Refresh(); // IE의 고질적인 문제 때문에 refresh
                url = browser.Url.ToString();
            }
            else
            {
                url = browser.Url.ToString();
            }
        }
    }
}
