using mshtml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using CustomUIControls;

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
        int PAGENUM = 3; // board 배열 선언 숫자 & setBoard의 epage도 바꿔주어야 함

        PortalBoard[] board1 = new PortalBoard[3 * 10];
        PortalBoard[] board2 = new PortalBoard[3 * 10];
        PortalBoard[] board3 = new PortalBoard[3 * 10];
        PortalBoard[] board4 = new PortalBoard[3 * 10];
        PortalBoard[] new_board4 = new PortalBoard[3 * 10];

        string a1 = "B200902281833482321051";
        string a2 = "B200902281833016691048";
        string a3 = "B201003111719010571299";

        IHTMLDocument2 doc = null;
        HttpWebRequest wReq;
        HttpWebResponse wRes;
        string resResult = string.Empty;
        string cookie;
        Uri uri;

        TaskbarNotifier taskbarNotifier;

        public Portal(string cookie)
        {
            this.cookie = cookie;

            // board 초기화
            for (int i = 0; i < PAGENUM * 10; i++)
            {
                board1[i] = new PortalBoard();
                board2[i] = new PortalBoard();
                board3[i] = new PortalBoard();
                board4[i] = new PortalBoard();
                new_board4[i] = new PortalBoard();
            }

            setBoard(board1, a1, 1, 3);
            setBoard(board2, a2, 1, 3);
            setBoard(board3, a3, 1, 3);
            setLastestBoard(1, 3);

            taskbarNotifier = new TaskbarNotifier();
            taskbarNotifier.SetBackgroundBitmap(new Bitmap(GetType(), "skin.bmp"), Color.FromArgb(255, 0, 255));
            taskbarNotifier.SetCloseBitmap(new Bitmap(GetType(), "close.bmp"), Color.FromArgb(255, 0, 255), new Point(121, 13));
            taskbarNotifier.TitleRectangle = new Rectangle(40, 13, 80, 25);
            taskbarNotifier.ContentRectangle = new Rectangle(12, 30, 125, 72);
            taskbarNotifier.CloseClickable = true;
            taskbarNotifier.TitleClickable = false;
            taskbarNotifier.ContentClickable = true;
            taskbarNotifier.EnableSelectionRectangle = true;
            taskbarNotifier.KeepVisibleOnMousOver = true;
            taskbarNotifier.ReShowOnMouseOver = true;

            taskbarNotifier.Show("새 글 알리미", "\n포탈 공지의 새 글을\n 알려줍니다 :)", 500, 3000, 500);
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

        public PortalBoard[] getBoard(int boardId)
        {
            switch (boardId)
            {
                case 1:
                    return board1;
                case 2:
                    return board2;
                case 3:
                    return board3;
                case 4:
                    return board4;
            }

            return board1;
        }

        public string getBoardId(int boardId, int index=0)
        {
            switch (boardId)
            {
                case 1:
                    return "B200902281833482321051";
                case 2:
                    return "B200902281833016691048";
                case 3:
                    return "B201003111719010571299";
                case 4:
                    return board4[index].boardId;
            }

            return "";
        }

        public string getBoardbullId(int boardId, int index)
        {
            switch (boardId)
            {
                case 1:
                    return board1[index].bullId;
                case 2:
                    return board2[index].bullId;
                case 3:
                    return board3[index].bullId;
                case 4:
                    return board4[index].bullId;;
            }

            return "";
        }

        public void setBoard(int boardId, int sPage = 1, int ePage = 3)
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
                case 4:
                    setLastestBoard(sPage, ePage);
                    break;
            }
        }

        private void setLastestBoard(int sPage, int ePage)
        {
            for (int pageNum = sPage; pageNum <= ePage; pageNum++)
            {
                MainForm.gridView.Columns[4].HeaderText = "게시판";

                string url = "http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp?nfirst=" + pageNum;
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

                for (int i = 0; i < docNum / 11; i++)
                {
                    string[] rows = new string[5];
                    IHTMLElement title = titles.ElementAt(i);
                    
                    int titleLen = 30;

                    if (title.innerText.Count() > titleLen)
                    {
                        rows[1] += title.innerText.Substring(0, titleLen);
                        rows[1] += "\r\n";
                        rows[1] += title.innerText.Substring(titleLen);
                    }
                    else
                    {
                        rows[1] = title.innerText;
                    }
                    rows[2] = elements.ElementAt(i * 11 + 5).innerText;
                    rows[3] = elements.ElementAt(i * 11 + 7).innerText;
                    rows[4] = elements.ElementAt(i * 11 + 3).innerText;

                    index = (pageNum - 1) * 10 + i;

                    board4[index].rows = rows;
                    //board4[index].title = rows[1];
                    //board4[index].writer = rows[2];
                    //board4[index].date = rows[3];
                    board4[index].boardName = rows[4];
                    //board[index].viewCount = Convert.ToInt32(rows[3]);
                    board4[index].page = pageNum;
                    board4[index].boardId = title.innerHTML.Substring(title.innerHTML.IndexOf("boardid=")).Substring(8);
                    board4[index].boardId = board4[index].boardId.Substring(0, board4[index].boardId.IndexOf("&"));
                    board4[index].bullId = title.innerHTML.Substring(title.innerHTML.IndexOf("bullid=")).Substring(7);
                    board4[index].bullId = board4[index].bullId.Substring(0, board4[index].bullId.IndexOf("&"));
                }
            }
        }

        public void checkNewLastestBoard()
        {
            int diffCount = setNewLastestBoard();

            if (diffCount == 0)
                return;
            else
            {
                for (int i = 0; i < diffCount; i++)
                {
                    // 학사 공지
                    if (new_board4[i].boardId == "B200902281833482321051")
                    {
                        for (int j = board1.Count() - 2; j >= 0; j--)
                        {
                            board1[j + 1] = board1[j];
                        }

                        board1[0] = new_board4[i];

                        taskbarNotifier.Show("학사 공지", board1[0].rows[1], 500, 3000, 500);
                    }
                    // 전체 공지
                    else if (new_board4[i].boardId == "B200902281833016691048")
                    {
                        for (int j = board2.Count() - 2; j >= 0; j--)
                        {
                            board2[j + 1] = board2[j];
                        }

                        board2[0] = new_board4[i];

                        taskbarNotifier.Show("전체 공지", board2[0].rows[1], 500, 3000, 500);
                    }
                    // 대학원 공지
                    else if (new_board4[i].boardId == "B201003111719010571299")
                    {
                        for (int j = board3.Count() - 2; j >= 0; j--)
                        {
                            board3[j + 1] = board3[j];
                        }

                        board3[0] = new_board4[i];

                        taskbarNotifier.Show("대학원 공지", board3[0].rows[1], 500, 3000, 500);
                    }
                }
            }
        }

        void CloseClick(object obj, EventArgs ea)
        {
            MessageBox.Show("Closed was Clicked");
        }

        void TitleClick(object obj, EventArgs ea)
        {
            MessageBox.Show("Title was Clicked");
        }

        void ContentClick(object obj, EventArgs ea)
        {
            MessageBox.Show("Content was Clicked");
        }

        private int setNewLastestBoard()
        {
            int diffCount = 0;

            for (int i = 0; i < PAGENUM * 10; i++)
                new_board4[i] = new PortalBoard();
            
            for (int pageNum = 0; pageNum <= PAGENUM; pageNum++)
            {
                string url = "http://portal.unist.ac.kr/EP/web/collaboration/bbs/jsp/BB_MyBoardLst.jsp?nfirst=" + pageNum;
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

                for (int i = 0; i < docNum / 11; i++)
                {
                    string[] rows = new string[5];
                    IHTMLElement title = titles.ElementAt(i);

                    int titleLen = 30;

                    if (title.innerText.Count() > titleLen)
                    {
                        rows[1] += title.innerText.Substring(0, titleLen);
                        rows[1] += "\r\n";
                        rows[1] += title.innerText.Substring(titleLen);
                    }
                    else
                    {
                        rows[1] = title.innerText;
                    }

                    if (rows[1] == board4[0].rows[1 + diffCount])
                    {
                        return diffCount;
                    }
                    else
                    {
                        diffCount++;
                    }

                    rows[2] = elements.ElementAt(i * 11 + 5).innerText;
                    rows[3] = elements.ElementAt(i * 11 + 7).innerText;
                    rows[4] = elements.ElementAt(i * 11 + 3).innerText;

                    index = (pageNum - 1) * 10 + i;

                    new_board4[index].rows = rows;
                    new_board4[index].boardName = rows[4];
                    new_board4[index].page = pageNum;
                    new_board4[index].boardId = title.innerHTML.Substring(title.innerHTML.IndexOf("boardid=")).Substring(8);
                    new_board4[index].boardId = board4[index].boardId.Substring(0, board4[index].boardId.IndexOf("&"));
                    new_board4[index].bullId = title.innerHTML.Substring(title.innerHTML.IndexOf("bullid=")).Substring(7);
                    new_board4[index].bullId = board4[index].bullId.Substring(0, board4[index].bullId.IndexOf("&"));
                }
            }

            return diffCount;
        }

        private void setBoard(PortalBoard[] board, string boardId, int sPage, int ePage) 
        {
            MainForm.gridView.Columns[4].HeaderText = "조회수";

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
