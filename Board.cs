using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace robot
{
    public class Board
    {
        // public string title;
        // public string writer;
        // public int viewCount;
        // public string date;
        public string boardId; // 게시판 아이디
        public string bullId; // 글 아이디
        public int page;
        public Color color;
        public bool bold;
        public string[] rows;

        public bool newPost; // 새 글인지 아닌지
        public bool anouncement; // 공지 글인지 아닌지

        public string boardName; // 최신 게시글 용 

        public Board()
        {
            bold = false;
            color = Color.Black;
            newPost = false;
            anouncement = false;
        }
    }
}
