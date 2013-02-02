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
    /* 
     * 학사 공지 : B200902281833482321051
     * 전체 공지 : B200902281833016691048
     * 대학원 공지 : B201003111719010571299
     * 최신 게시물 :
     * 
     * 학사 공지 주소 (nfirst : 페이지 번호)
     *  http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=B200902281833482321051&nfirst=3
     * 
     * 게시글 주소 (bullid : 게시물 id)
     *  http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardView.jsp?boardid=B200902281833482321051&bullid=BB201301081415252548044
     * 
     */

    class Portal
    {
        int BOARDTAGNUM = 13;
        int PAGENUM = 3; // board 배열 선언 숫자도 바꿔주어야 함
        Board[] board1 = new Board[3 * 10];
        Board[] board2 = new Board[3 * 10];
        Board[] board3 = new Board[3 * 10];

        string a1 = "B200902281833482321051";
        string a2 = "B200902281833016691048";
        string a3 = "B201003111719010571299";

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        UTF8Encoding encoding;
        byte[] bytes;

        public Portal(string cookie)
        {
            this.cookie = cookie;

            // board 초기화
            for (int i = 0; i < PAGENUM * 10; i++)
            {
                board1[i] = new Board();
                board2[i] = new Board();
                board3[i] = new Board();
            }

            setBoard(board1, a1, 1, 3);
            // setBoard(board2, a2, 1, 3);
            // setBoard(board3, a3, 1, 3);
        }

        // 클래스 이름으로 htmlelment 받는 함수
        static IEnumerable<IHTMLElement> ElementsByClass(IHTMLDocument2 doc, string className)
        {
            foreach (IHTMLElement e in doc.all)
                if (e is mshtml.IHTMLTableCell)
                    if(e.className==className)
                        yield return e;
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

        public Board[] getBoard(int boardId)
        {
            switch (boardId)
            {
                case 1:
                    return board1;
                case 2:
                    return board2;
                case 3:
                    return board3;
            }

            return board1;
        }

        public void setBoard(int boardId, int sPage, int ePage)
        {
            switch (boardId)
            {
                case 1:
                    setBoard(board1, a1, sPage, ePage);
                    break;
                case 2:
                    setBoard(board2, a2, sPage, ePage);
                    break;
                case 3:
                    setBoard(board3, a3, sPage, ePage);
                    break;
            }
        }

        private void setBoard(Board[] board, string boardId, int sPage, int ePage) 
        {
            for (int pageNum = sPage; pageNum <= ePage; pageNum++)
            {
                string url = "http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_BoardLst.jsp?boardid=" + boardId + "&nfirst=" + pageNum;
                wRes = getRespose(url);

                // http 내용 추출
                Stream respPostStream = wRes.GetResponseStream();
                StreamReader readerPost = new StreamReader(respPostStream, Encoding.Default);

                resResult = readerPost.ReadToEnd();

                doc = (IHTMLDocument2)new HTMLDocument();
                doc.clear();
                doc.write(resResult);
                doc.close();

                IEnumerable<IHTMLElement> titles = ElementsByClass(doc, "ltb_left");
                IEnumerable<IHTMLElement> elements = ElementsByClass(doc, "ltb_center");

                int docNum = elements.Count();
                int index;

                for (int i = 0; i < docNum / BOARDTAGNUM; i++)
                {
                    string[] rows = new string[5];
                    IHTMLElement title = titles.ElementAt(i);
                    
                    rows[0] = "";
                    rows[1] = title.innerText;
                    rows[2] = elements.ElementAt(i * BOARDTAGNUM + 5).innerText;
                    rows[3] = elements.ElementAt(i * BOARDTAGNUM + 7).innerText;
                    rows[4] = elements.ElementAt(i * BOARDTAGNUM + 9).innerText;
                    
                    index = (pageNum - 1) * 10 + i;

                    // new 체크
                    if (((IHTMLElement2)title).getElementsByTagName("img").length > 0)
                    {
                        board[index].newPost = true;
                        rows[0] = "new";
                    }

                    // 공지 체크
                    if (((IHTMLElement2)elements.ElementAt(i * BOARDTAGNUM + 1)).getElementsByTagName("img").length > 0)
                    {
                        board[index].anouncement = true;
                        rows[0] = "공지";
                    }

                    board[index].rows = rows;
                    //board[index].title = rows[1];
                    //board[index].writer = rows[2];
                    //board[index].date = rows[3];
                    //board[index].viewCount = Convert.ToInt32(rows[4]);
                    board[index].page = pageNum;
                    board[index].boardId = boardId;

                    // javascript:clickBulletin("BB201302011329070365135","BB201302011329070365135","BB201302011329070365135","0","N");
                    string javaUrl = title.innerHTML.Substring(title.innerHTML.IndexOf("javascript:"));
                    board[index].bullId = javaUrl.Split('\"')[1];

                    IHTMLElement font = (IHTMLElement)((IHTMLElement2)title).getElementsByTagName("font").item(0,0);

                    if (font.getAttribute("color") != null)
                    {
                        board[index].color = ConvertColor_PhotoShopStyle_toRGB((string)font.getAttribute("color"));
                    }

                    if (title.outerHTML.IndexOf("FONT-WEIGHT: bold") != -1)
                    {
                        board[index].bold = true;
                    }
                }
            }
        }

        private Color ConvertColor_PhotoShopStyle_toRGB(string photoShopColor)
        {
            int red, green, blue;
            red = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(1, 2), 16));
            green = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(3, 2), 16));
            blue = Convert.ToInt32(Convert.ToByte(photoShopColor.Substring(5, 2), 16));

            return Color.FromArgb(red, green, blue);
        }
    }
}
