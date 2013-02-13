using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace robot
{
    class BBBoard
    {
        public string url;
        public string name;
        public List<string> menu;
        public List<string> menuUrl;

        public void bbboard_click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem butitem = (DevComponents.DotNetBar.ButtonItem)sender;
            MainForm.brows.Navigate("bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=" + url);
            //bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=_11194_1
        }

        public void bbSideItem_click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem butitem = (DevComponents.DotNetBar.ButtonItem)sender;

            for (int i = 0; i < menu.Count; i++)
            {
                if (menu[i] == butitem.Text)
                {
                    MainForm.brows.Navigate(menuUrl[i]);
                    return;
                }
            }

            // http://bb.unist.ac.kr/webapps/blackboard/content/courseMenu.jsp?course_id=_11433_1&newWindow=true&openInParentWindow=true
        }
    }
}
