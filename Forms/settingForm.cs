using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace robot
{
    public partial class SettingForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public DevComponents.DotNetBar.Controls.SwitchButton loginSwitch;
        public DevComponents.DotNetBar.Controls.SwitchButton sayswitch;
        AutoLogin autologin;

        public SettingForm()
        {
            InitializeComponent();

            loginSwitch = this.autoLoginSwitch;
            sayswitch = this.saySwitch;

            alarmTip.SetToolTip(alarmLabel, "새 글 알림 기능을 끄고 켤 수 있습니다 :-(");
            autoLoginTip.SetToolTip(autoLoginLabel, "자동 로그인 기능을 끄고 켤 수 있습니다 :-|");
            sayTip.SetToolTip(sayLabel, "랜덤 명언을 보이거나 안보이게 할 수 있습니다 :-)");
            
            autologin = new AutoLogin();
        }

        public void autoLoginSwitch_ValueChanged(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.SwitchButton check = (DevComponents.DotNetBar.Controls.SwitchButton)sender;

            if (MainForm.isLoading == true)
            {
                return;
            }

            else
            {
                if (check.Value == true)
                {
                    DialogResult result = MessageBox.Show("개인정보가 유출될 수 있습니다.\r\n자동 로그인을 하시겠습니까? :[", "Robot의 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.No)
                    {
                        check.Value = false;
                        return;
                    }

                    if (MainForm.isLoading != true)
                    {
                        autologin.WriteRegistry(Program.id, Program.password);
                    }

                }
                if (check.Value == false)
                {
                    autologin.WriteRegistry("", "");
                }
            }
        }

        private void alarmSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (alarmSwitch.Value == false)
            {
                MainForm.timer1.Stop();
            }
            else
            {
                MainForm.timer1.Start();
            }
        }


        private void saySwitch_ValueChanged(object sender, EventArgs e)
        {
            if (saySwitch.Value == true)
            {
                MainForm.saylabel.Visible = true;
                MainForm.timer2.Start();
            }
            else
            {
                MainForm.saylabel.Visible = false;
                MainForm.timer2.Stop();
            }
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.isExiting == false)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright (c) 2013 Kim Tae Hoon ಠ_ಠ", ":^)");
        }

        private void SettingForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                MainForm.settingClick.Visible = true;
            }
            else
            {
                MainForm.settingClick.Visible = false;
            }
        }
    }
}
