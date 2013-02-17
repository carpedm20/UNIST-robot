using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace robot
{
    class DormBoard
    {
        public string link; // 글 아이디
        public int page;
        public int wiewCount;
        public string postDate;
        public string title;
        public string[] rows;
        public bool anouncement; // 공지 글인지 아닌지

        public DormBoard()
        {
            link = "";
            postDate = "";
            title = "";
            rows = new string[5];
            anouncement = false;
        }
    }
}
