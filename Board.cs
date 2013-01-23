using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot
{
    public class Board
    {
        public string title;
        public string writer;
        public int viewCount;
        public string date;
        public string boardId;
        public int page;

        public bool newPost; // 새 글인지 아닌지
        public bool anouncement; // 공지 글인지 아닌지

        public string boardName; // 최신 게시글 용 
        public string[] javascript=new string[5];

        public Board()
        {
            newPost = false;
            anouncement = false;
        }
    }
}
