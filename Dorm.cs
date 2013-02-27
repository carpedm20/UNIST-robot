using MSHTML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace robot
{
    class Dorm
    {
        DormBoard[] boards;
        int MAXPAGE = 3; // setBoard 바꿔주어야함

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        TaskbarNotifier taskbarNotifier;
        MainForm mainForm;


        public Dorm(string cookie, MainForm mainForm)
        {
            this.cookie = cookie;
            this.mainForm = mainForm;

            for (int i = 0; i < MAXPAGE; i++)
                boards[i] = new DormBoard();

            setBoard();
        }

        private void setBoard(int sPage = 1, int ePage = 3)
        {
            for (int i = 0; i < 3 * 10; i++)
            {
                boards[i] = new DormBoard();
            }

            for (int pageNum = sPage; pageNum <= ePage; pageNum++)
            {
                // http://dorm.unist.ac.kr/admin/board/view.asp?intNowPage=1&board_nm=dorm_notice&idx=2885

                string url = "http://dorm.unist.ac.kr/admin/board/list.asp?board_nm=dorm_notice&intNowPage=" + pageNum;
                if (!getResponse(url))
                    return;

                doc = (IHTMLDocument2)new HTMLDocument();
                doc.clear();
                doc.write(resResult);
                doc.close();

                IEnumerable<IHTMLElement> tags = ElementsByTagName(doc, "tr");
                string[] rows = new string[5];

                for (int i = 1; i < tags.Count(); i++)
                {
                    string html=tags.ElementAt(i).innerHTML;
                    boards[i].link = html.Split('\'')[0];

                }
            }
        }

        static IEnumerable<IHTMLElement> ElementsByTagName(IHTMLDocument2 doc, string tagName)
        {
            foreach (IHTMLElement e in doc.all)
                    if (e.tagName == tagName)
                        yield return e;
        }

        static IEnumerable<IHTMLElement> ElementsByClass(IHTMLElementCollection doc, string classname)
        {
            foreach (IHTMLElement e in doc)
                if (e.className == classname)
                    yield return e;
        }

        private bool getResponse(String url)
        {
            try
            {
                uri = new Uri(url);
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "GET";
                wReq.CookieContainer = new CookieContainer();
                wReq.CookieContainer.SetCookies(uri, cookie);

                using (wRes = (HttpWebResponse)wReq.GetResponse())
                {
                    Stream respPostStream = wRes.GetResponseStream();
                    StreamReader readerPost = new StreamReader(respPostStream, Encoding.Default);

                    resResult = readerPost.ReadToEnd();
                }

                return true;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                {
                    var resp = (HttpWebResponse)ex.Response;
                    if (resp.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Do something
                    }
                    else
                    {
                        // Do something else
                    }
                }
                else
                {
                    // Do something else
                }

                return false;
            }
        }
    }
}
