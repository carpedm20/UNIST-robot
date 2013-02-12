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
using System.Xml;

namespace robot
{
    class Library
    {
        public Book[] books;

        string bookQuery;

        string bookQuery1;
        string bookQuery2;
        string bookOption1;
        string bookOption2;
        string bookOperator;

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        public Library(string cookie)
        {
            if (cookie == null)
                this.cookie = "";
            else
                this.cookie = cookie;

            bookQuery = "";
            bookQuery1 = "";
            bookQuery2 = "";
            bookOption1 = "";
            bookOption2 = "";
            bookOperator = "";
        }

        public void bookSearch(string bq1, string bq2, string bo1, string bo2, string bo)
        {
            this.bookQuery1 = bq1;
            this.bookQuery2 = bq2;
            this.bookOption1 = bo1;
            this.bookOption2 = bo2;
            this.bookOperator = bo;

            bookQuery = queryMake();

            string url = "http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Results.aspx?" + bookQuery;
            wRes = getRespose(url);

            // http 내용 추출
            Stream respPostStream = wRes.GetResponseStream();
            StreamReader readerPost = new StreamReader(respPostStream);

            resResult = readerPost.ReadToEnd();

            doc = (IHTMLDocument2)new HTMLDocument();
            doc.clear();
            doc.write(resResult);
            doc.close();

            IEnumerable<IHTMLElement> elements = ElementsByClass(doc, "item");

            books = new Book[elements.Count()];

            for (int i = 0; i < elements.Count(); i++)
            {
                string[] rows = new string[5];

                books[i] = new Book();
                string html = elements.ElementAt(i).innerHTML;

                if (html.IndexOf("no thumbnail") != -1)
                {
                    books[i].thumbnail = "";
                }
                else
                {
                    books[i].thumbnail = html.Substring(html.IndexOf("thumb.axd?url=")).Split('\"')[0];
                }

                IHTMLElement title = (IHTMLElement)((IHTMLElement2)elements.ElementAt(i)).getElementsByTagName("label").item(0, 0);

                rows[0] = books[i].title = title.getAttribute("title").ToString().Split('/')[0].Replace("선택하기", "");
                rows[1] = books[i].author = html.Substring(html.IndexOf("author\">")).Split('>')[1].Split('<')[0];
                rows[2] = books[i].publisher = html.Substring(html.IndexOf("publisher\">")).Split('>')[1].Split('<')[0];
                rows[3] = books[i].publishYear = html.Substring(html.IndexOf("publishyear\">")).Split('>')[1].Split('<')[0];
                rows[4] = books[i].isbn = html.Substring(html.IndexOf("isbn\">")).Split('>')[1].Split('<')[0];

                IHTMLElement cid = (IHTMLElement)(((IHTMLElement2)elements.ElementAt(i)).getElementsByTagName("input").item(0, 0));

                // 도서 상태를 위한 cid
                books[i].cid = cid.getAttribute("value").ToString();

                if (html.IndexOf("Domestic Books") != -1)
                {
                    books[i].kind = "국내 서적";
                }

                books[i].rows = rows;
            }

            //http://library.unist.ac.kr/DLiWeb25Eng/comp/search/Results.aspx?method=2&field=TITL,AUTH,PUBN&keyword=%ED%95%B4%ED%82%B9,%ED%95%B4%ED%82%B9,%ED%95%B4%ED%82%B9&operator=0,1,3&branch=01&classid=24,27,1,60,32,65,21,23,25,39,75,2,22,41,38,74,88,52,33,6,19,80,29,59,85,89,63,5,28,16,77,30,73,53,34,64,79,26,90,35,3,4,15,20,42,76,86,91&max=300&classifyname=KDC&classify=&cntperpage=20&viewoption=1&sort=DEFAULT
        }

        public string[] loadBookStat(string cid)
        {
            // http://library.unist.ac.kr/DLiWeb25Eng/comp/search/SearchHandler.aspx?action=stock&cid=357465
            // | 번호 | 등록 번호 | 소장 위치 | 도서 상태 | 청구 기호 | 출력 |

            string url = "http://library.unist.ac.kr/DLiWeb25Eng/comp/search/SearchHandler.aspx?action=stock&cid=" + cid;
            wRes = getRespose(url);

            // http 내용 추출
            Stream respPostStream = wRes.GetResponseStream();
            StreamReader readerPost = new StreamReader(respPostStream);

            resResult = readerPost.ReadToEnd();

            doc = (IHTMLDocument2)new HTMLDocument();
            doc.clear();
            doc.write(resResult);
            doc.close();

            //IEnumerable<HtmlElement> elements = ElementsByClass(doc, "stock_callnumber");

            IEnumerable<IHTMLElement> e = getTableRow(doc);
            IEnumerator<IHTMLElement> enumerator = e.GetEnumerator();

            string[] rows = new string[(e.Count() - 1) * 4];
            int count=0;

            enumerator.MoveNext();
            while(enumerator.MoveNext()) {
                IHTMLElement2 e2 = (IHTMLElement2)enumerator.Current;
                rows[count++] = ((IHTMLElement)(e2.getElementsByTagName("td").item(3, 0))).innerText;
                rows[count++] = ((IHTMLElement)(e2.getElementsByTagName("td").item(2, 0))).innerText;
                rows[count++] = ((IHTMLElement)(e2.getElementsByTagName("td").item(4, 0))).innerText;
                rows[count++] = ((IHTMLElement)(e2.getElementsByTagName("td").item(1, 0))).innerText;
            }

            return rows;
        }

        public string[] loadBookReview(string isbn)
        {
            string url="";
            string[] review=new string[2];

            review[0] = "";
            review[1] = "";

            XmlDocument docX = new XmlDocument();
            docX.Load("http://openapi.naver.com/search?key=6053ca2ccd452f386a6e2eb44375d160&query=art&target=book_adv&d_isbn=" + isbn);

            XmlNodeList elemList = docX.GetElementsByTagName("link");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].InnerText != "http://search.naver.com")
                {
                    url = elemList[i].InnerXml;
                    break;
                }
            }

            wRes = getRespose(url);

            // http 내용 추출
            Stream respPostStream = wRes.GetResponseStream();
            StreamReader readerPost = new StreamReader(respPostStream);

            resResult = readerPost.ReadToEnd();

            doc = (IHTMLDocument2)new HTMLDocument();
            doc.clear();
            doc.write(resResult);
            doc.close();

            string html = resResult;

            IHTMLElement2 element = (IHTMLElement2)(ElementsByClass(doc, "txt_desc").ElementAt(0));
            review[0] += element.getElementsByTagName("strong").item(0, 0).ToString();
            review[0] += html.Substring(html.IndexOf("네티즌리뷰")).Split('건')[0];
            review[0] += ((IHTMLElement)element).innerText.Split('|')[0] + "("
                + ((IHTMLElement)element).innerText.Split('|')[1].Substring(6) + ")";
            review[1] = ((IHTMLElement)(element.getElementsByTagName("a").item(0, 0))).getAttribute("href").ToString();

            return review;
        }

        public string queryMake()
        {
            string query = "method=2";

            if (bookQuery1 != null && bookQuery2 == null)
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery1);
                query += "&field=";

                if (bookOption1 == "제목")
                    query += "TITL";
                else if (bookOption1 == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }
                query += "&operator=0";
            }
            else if (bookQuery1 == null && bookQuery2 != null)
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery2);
                query += "&field=";

                if (bookOption2 == "제목")
                    query += "TITL";
                else if (bookOption2 == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }
                query += "&operator=0";
            }
            else
            {
                query += "&keyword=" + HttpUtility.UrlEncode(bookQuery1) + "," + HttpUtility.UrlEncode(bookQuery2);
                query += "&field=";

                if (bookOption1 == "제목")
                    query += "TITL";
                else if (bookOption1 == "저자")
                    query += "AUTH";
                else
                {
                    query += "PUBN";
                }

                if (bookOption2 == "제목")
                    query += ",TITL";
                else if (bookOption2 == "저자")
                    query += ",AUTH";
                else
                {
                    query += ",PUBN";
                }

                query += "&operator=0,";

                if (bookOperator == "AND")
                {
                    query += "1";
                }
                else if (bookOperator == "OR")
                {
                    query += "2";
                }
                else
                {
                    query += "3";
                }
            }

            query += "&cntperpage=100&viewoption=1&sort=DEFAULT";

            return query; // 최종 쿼리 넘겨줌
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

        static IEnumerable<IHTMLElement> ElementsByClass(IHTMLDocument2 doc, string className)
        {
            foreach (IHTMLElement e in doc.all)
                // if (e is mshtml.IHTMLDivElement)
                    if (e.className == className)
                        yield return e;
        }

        static IEnumerable<IHTMLElement> getTableRow(IHTMLDocument2 doc)
        {
            foreach (IHTMLElement e in doc.all)
                if (e is mshtml.IHTMLTableRow)
                    yield return e;
        }
    }
}
