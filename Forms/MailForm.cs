using mshtml;
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
    public partial class MailForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        bool messageCheck;
        bool toCheck;

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        string original = "carpedm20@gmail.com 으로\r\n\r\n버그, 건의 사항 및 기타 의견을 보내주세요~\r\n\r\n여러분의 의견, 언제나 환영합니다 :)";

        public MailForm(string cookie)
        {
            InitializeComponent();

            messageCheck = false;
            toCheck = false;
            this.cookie = cookie;

            fromLabel.Text += Program.id + "@unist.ac.kr";
        }

        private void sendBox_Click(object sender, EventArgs e)
        {
            if (contentText.Text == "")
            {
                MessageBox.Show("내용이 없습니다 :(", "Robot의 경고");
                return;
            }

            if (contentText.Text == original)
            {
                MessageBox.Show("내용은 수정해서 보내주세요 :)");
                return;
            }

            string url = "http://mail.unist.ac.kr/mail/writeMail.crd";
            if (!getResponse(url, makeArgument()))
                return;

            if (wRes.StatusDescription == "OK")
            {
                MessageBox.Show("성공적으로 전송 되었습니다 ;)");
                this.Visible = false;
            }

            else
            {
                MessageBox.Show("전송에 실패했습니다 :(", "Robot의 경고");
            }
        }

        private string makeArgument()
        {
            //send_mail_type=now&body=++++%3Cstyle%3E+%09%09++%09+%23mailBodyContentDiv+%7B+font-family+%3A+Dotum%2C+Verdana%2C+Arial%2C+Helvetica+%3B+background-color%3A+%23ffffff%3Bfont-size%3A10pt%3B%7D++++%09%09+%23mailBodyContentDiv+BODY+%7B+background-color%3A+%23ffffff%3B%7D++++++++++++%23mailBodyContentDiv+BODY%2C+TD%2C+TH+%7B+color%3A+black%3B+font-family%3A+Dotum%2C+Verdana%2C+Arial%2C+Helvetica%3B+font-size%3A+10pt%3B+%7D++++++++++++%23mailBodyContentDiv+P+%7B+margin%3A+0px%3B+padding%3A2px%3B%7D+++++%3C%2Fstyle%3E++++%3Cdiv+id%3D%22mailBodyContentDiv%22+style%3D%22width%3A100%25%22%3E+%3Cspan+style%3D%22font-family%3A+Dotum%3B+font-size%3A+small%3B%22%3E123123123%EC%95%88%EB%85%95%ED%95%98%EC%84%B8%EC%9A%94%3C%2Fspan%3E++++%3C%2Fdiv%3E+&charset=EUC-KR&sender_mail=carpedm20%40unist.ac.kr&to=carpedm20%40gmail.com&subject=hello&SenderName=%EA%B9%80%ED%83%9C%ED%9B%88&uploadServer=mail.unist.ac.kr&uploadPort=80&userId=Y2FycGVkbTIwQHVuaXN0LmFjLmty&sender_name=%EA%B9%80%ED%83%9C%ED%9B%88&send_dt_ymd=20130213&send_dt_hour=10&send_dt_min=54

            string arg = "send_mail_type=now&body=++++%3Cstyle%3E+%09%09++%09+%23mailBodyContentDiv+%7B+font-family+%3A+Dotum%2C+Verdana%2C+Arial%2C+Helvetica+%3B+background-color%3A+%23ffffff%3Bfont-size%3A10pt%3B%7D++++%09%09+%23mailBodyContentDiv+BODY+%7B+background-color%3A+%23ffffff%3B%7D++++++++++++%23mailBodyContentDiv+BODY%2C+TD%2C+TH+%7B+color%3A+black%3B+font-family%3A+Dotum%2C+Verdana%2C+Arial%2C+Helvetica%3B+font-size%3A+10pt%3B+%7D++++++++++++%23mailBodyContentDiv+P+%7B+margin%3A+0px%3B+padding%3A2px%3B%7D+++++%3C%2Fstyle%3E++++%3Cdiv+id%3D%22mailBodyContentDiv%22+style%3D%22width%3A100%25%22%3E+%3Cspan+style%3D%22font-family%3A+Dotum%3B+font-size%3A+small%3B%22%3E";
            arg += contentText.Text.Replace("\r\n", "<br/>");
            arg += "%3C%2Fspan%3E++++%3C%2Fdiv%3E+&charset=EUC-KR&sender_mail=";
            arg += Program.id + "%40unist.ac.kr&to=" + HttpUtility.UrlEncode(toBox.Text) + "&subject=" + "Robot 리포트";
            arg += "&SenderName="+MainForm.userName+"&uploadServer=mail.unist.ac.kr&uploadPort=80";
            arg += "&userId=";
            arg += "&sender_name=" + MainForm.userName;

            return arg;
        }

        private void contentText_TextChanged(object sender, EventArgs e)
        {
            if (messageCheck == false)
            {
                messageCheck = true;
                contentText.Text = "";
            }
        }

        private bool getResponse(String url, string data)
        {
            try
            {
                uri = new Uri(url);
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "POST";
                wReq.CookieContainer = new CookieContainer();
                wReq.CookieContainer.SetCookies(uri, cookie);

                wReq.Headers.Add("Origin: http://mail.unist.ac.kr");
                wReq.ContentType = "application/x-www-form-urlencoded";
                wReq.Referer = "http://mail.unist.ac.kr/mail/toMailWrite.crd";

                byte[] byteArray = Encoding.UTF8.GetBytes(data);

                Stream dataStream = wReq.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

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

        private void MailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void contentText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    contentText.SelectAll();
                }
            }
        }

        private void toBox_TextChanged(object sender, EventArgs e)
        {
            if (toCheck == false)
            {
                toCheck = true;
                contentText.Text = "";
            }
        }

        private void MailForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                MainForm.mailClick.Visible = true;
            }
            else
            {
                MainForm.mailClick.Visible = false;
            }
        }
    }
}
