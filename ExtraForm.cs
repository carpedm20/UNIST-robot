using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace robot
{
    public partial class ExtraForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        static public WebBrowser browser;
        static public bool isEnd;

        public ExtraForm(string url)
        {
            InitializeComponent();
            
            browser = webBrowser;
            browser.Navigate(url);

            browser.ScriptErrorsSuppressed = true;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (browser.Document.Body.InnerText.IndexOf("Reserving Group study Rooms") != -1)
            {
                this.Visible = false;
            }
        }

        private void webBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}