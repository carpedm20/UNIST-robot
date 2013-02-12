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

        public void bbboard_click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem butitem = (DevComponents.DotNetBar.ButtonItem)sender;
            Form1.brows.Navigate("bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=" + url);
            //bb.unist.ac.kr/webapps/blackboard/execute/announcement?&method=search&viewChoice=3&searchSelect=_11194_1
        }
    }
}
