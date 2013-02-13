using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace robot
{
    public class Program
    {
        // 전역 변수 선언
        public static string id, password;
        public static bool loginSave = true, autoLogin = true;
        public static bool login = false;
        public static LoginForm f2;
        public static MainForm f1;

        // ini file 변수
        public static FileInfo exefileinfo;
        public static string path, fileName, filePath;
        public static INI ini;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 파일 ini 파일
            exefileinfo = new FileInfo(Application.ExecutablePath);
            path = exefileinfo.Directory.FullName.ToString();  //프로그램 실행되고 있는데 path 가져오기
            fileName = @"\config.ini";
            filePath = path + fileName;
            ini = new INI(filePath);

            string auto = Program.ini.GetIniValue("Login", "Auto");

            id = ini.GetIniValue("Login", "Id");
            password = ini.GetIniValue("Login", "Password");

            if (auto == "true")
            {
                autoLogin = true;
            }
            else
            {
                autoLogin = false;
            }

            if (auto == "true")
            {
                f1 = new MainForm();
                Application.Run(f1);
            }
            else
            {
                f2 = new LoginForm();
                Application.Run(f2);

                if (login != false)
                {
                    f1 = new MainForm();
                    Application.Run(f1);
                }
            }
        }
    }
}
