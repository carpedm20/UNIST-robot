using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace robot
{
    class Book
    {
        public string title;
        public string author;
        public string publisher;
        public string publishYear;
        public string isbn;
        public string thumbnail;
        public string kind;
        public string cid; // 도서 상태 확인용
        public string[] rows;

        public Book()
        {
            title = "";
            author = "";
            publishYear = "";
            publisher = "";
            isbn = "";
            thumbnail = "";
            kind = "";
            cid = "";
        }
    }
}
