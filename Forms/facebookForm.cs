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

        string ieVersion;

        public FacebookForm()
        {
            InitializeComponent();

            this.Font = new Font(Program.myFonts.Families[0], 9);

            ieVersion = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer").GetValue("Version").ToString();

            if (ieVersion.IndexOf("9.10.") != -1)
            {
                ieUpdateLabel.Visible = false;
            }

            else
            {
                if (MainForm.ieUpdateChecked == true)
                {
                    ieUpdateLabel.Visible = false;
                }
            }

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
            // ie version이 10 이하인경우
            if (ieVersion.IndexOf("9.10.") == -1)
            {
                if (url != browser.Url.ToString())
                {
                    if (e.Url.ToString().IndexOf("side-area") == -1)
                        browser.Refresh(); // IE 9 이하의 고질적인 문제 때문에 refresh
                    url = browser.Url.ToString();
                }

                else
                {
                    url = browser.Url.ToString();
                }
            }
        }

        private void ieUpdateLabel_Click(object sender, EventArgs e)
        {
            ieUpdateLabel.Visible = false;
        }
    }
}
