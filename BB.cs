using mshtml;
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

        public BB(WebBrowser browser)
        {
            this.browser = browser;
            browser.Navigate("http://bb.unist.ac.kr/webapps/blackboard/execute/announcement?method=search&context=mybb&handle=my_announcements");
        }

        public void setBoard()
        {
            doc = browser.Document as HtmlDocument;
            HtmlElementCollection options = doc.GetElementsByTagName("Option");

            board = new BBBoard[options.Count - 3];

            int j = 0;

            for (int i = 3; i < options.Count; i++)
            {
                string n = options[i].InnerText.Replace("-", "");

                // Open Study 제외
                if (n.IndexOf("Open Study") != -1 || n.IndexOf("Organizations") != -1 || n.IndexOf("Survey") != -1)
                {
                    j++;
                    continue;
                }

                board[i - 3 - j] = new BBBoard();
                board[i - 3 - j].url = options[i].OuterHtml.Split('=')[1].Split('>')[0];
                board[i - 3 - j].name = n;
            }
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

                slideBlackBoard.SubItems.Add(butItem);
                
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
