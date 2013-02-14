using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace robot
{
    public partial class LoginForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        AutoLogin loginReg;

        public LoginForm()
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            loginReg = new AutoLogin();
        }

        public LoginForm(string id, string pw)
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            loginReg = new AutoLogin();

            idText.Text = id;
            passText.Text = pw;

            loginBtn_Click(null, null);
        }

        public LoginForm(string id)
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            loginReg = new AutoLogin();

            idText.Text = id;

            saveIdBox.Checked = true;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (idText.Text == "")
            {
                MessageBox.Show("아이디를 입력해 주세요");
            }
            else if (passText.Text == "")
            {
                MessageBox.Show("비밀번호를 입력해 주세요");
            }
            else
            {
                browser.Navigate("https://mail.unist.ac.kr/user/login.crd?charset=EUC-KR&my_char_set=default&result=&login_fail=null&encodeChallenge=true&locale=ko&userid=" + idText.Text + "&userdomain=unist.ac.kr&userpass=" + MD5HashFunc(passText.Text));
                
                Program.id = idText.Text;
                Program.password = passText.Text;

                this.Enabled = false;
            }
        }

        private void saveIdBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox) sender;

            if (check.Checked == true)
            {
                autoLoginBox.Enabled = true;
                loginReg.WriteRegistry(idText.Text, "");
            }
            else
            {
                autoLoginBox.Enabled = false;
                autoLoginBox.Checked = false;
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
                loginReg.WriteRegistry(idText.Text, passText.Text);
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
        }
    }   
}
