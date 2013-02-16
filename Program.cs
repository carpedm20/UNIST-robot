using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Net;

namespace robot
{
    public class Program
    {
        // 전역 변수 선언
        public static string id, password, md5;
        public static bool autoLogin = false;
        public static bool login = false;
        public static LoginForm f2;
        public static MainForm f1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoLogin loginReg = new AutoLogin();
            string regId = "", regPw = "";

            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Application.Exit();
                MessageBox.Show("인터넷 연결에 문제가 있습니다.\r\n 프로그램을 종료합니다. :^(", "Robot의 경고");
                System.Diagnostics.Process[] mProcess = System.Diagnostics.Process.GetProcessesByName(Application.ProductName);
                foreach (System.Diagnostics.Process p in mProcess)
                    p.Kill();
            }

            if (loginReg.ReadRegistry(ref regId, ref regPw))
            {
                if (regPw == "")
                {
                    f2 = new LoginForm(regId);
                    Application.Run(f2);
                }

                else
                {
                    id = regId;
                    password = regPw;
                    autoLogin = true;
                    f1 = new MainForm();
                    Application.Run(f1);
                }
            }
            else
            {
                f2 = new LoginForm();
                Application.Run(f2);
            }

            if (login == true)
            {
                f1 = new MainForm();
                Application.Run(f1);
            }
        }
    }
}
