using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace robot
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            browser.ScriptErrorsSuppressed = true;

            if (Program.ini != null)
            {
                string save = Program.ini.GetIniValue("Login", "Save");

                // id 저장 옵션 확인
                if (save == "true")
                {
                    idBox.Text = Program.ini.GetIniValue("Login", "Id");
                    saveIdBox.Checked = true;
                    Program.loginSave = true;

                    save = Program.ini.GetIniValue("Login", "Auto");

                    if (save == "true")
                    {
                        Program.autoLogin = true;
                    }
                }
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                MessageBox.Show("아이디를 입력해 주세요");
            }
            else if (passBox.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해 주세요");
            }
            else
            {
                browser.Navigate("https://mail.unist.ac.kr/user/login.crd?charset=EUC-KR&my_char_set=default&result=&login_fail=null&encodeChallenge=true&locale=ko&userid=" + idBox.Text + "&userdomain=unist.ac.kr&userpass=" + MD5HashFunc(passBox.Text));
                
                Program.id = idBox.Text;
                Program.password = passBox.Text;

                this.Enabled = false;

                //this.Enabled = false;
                //Form1 f1 = new Form1();
                //f1.Parent = this;
            }
        }

        private void saveIdBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox) sender;

            if (check.Checked == true)
            {
                autoLoginBox.Enabled = true;
                Program.loginSave = true;
            }
            else
            {
                autoLoginBox.Enabled = false;
                autoLoginBox.Checked = false;
                Program.loginSave = false;
            }
        }

        private void autoLoginBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (check.Checked == true)
            {
                DialogResult result = MessageBox.Show("개인정보가 유출될 수 있습니다.\r\n자동 로그인을 하시겠습니까? :[", "Robot의 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    check.Checked = false;
                    return;
                }
                Program.autoLogin = true;
            }
            else
            {
                Program.autoLogin = false;
            }
        }

        // 비밀번호 텍스트박스 엔터 입력
        private void passBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e);
            }
        }

        public string MD5HashFunc(string str)
        {
            StringBuilder MD5Str = new StringBuilder();
            byte[] byteArr = Encoding.ASCII.GetBytes(str);
            byte[] resultArr = (new MD5CryptoServiceProvider()).ComputeHash(byteArr);

            //for (int cnti = 1; cnti < resultArr.Length; cnti++) (2010.06.27)
            for (int cnti = 0; cnti < resultArr.Length; cnti++)
            {
                MD5Str.Append(resultArr[cnti].ToString("X2"));
            }
            return MD5Str.ToString().ToLower();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // mail.unist를 통해 로그인 검사
            if (e.Url.ToString() == "about:blank")
            {
                Program.login = true;
                this.Close();
            }

            this.Enabled = true;
            
            /*if(e.Url.ToString() == "")
            {
                MessageBox.Show("아이디 혹은 비밀번호가 틀렸습니다 :[", "Robot의 경고", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }*/
        }
    }   
}
