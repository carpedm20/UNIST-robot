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

        public SettingForm()
        {
            InitializeComponent();

            loginSwitch = this.autoLoginSwitch;
        }

        public void autoLoginSwitch_ValueChanged(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.Controls.SwitchButton check = (DevComponents.DotNetBar.Controls.SwitchButton)sender;

            if (check.Value == true)
            {
                DialogResult result = MessageBox.Show("개인정보가 유출될 수 있습니다.\r\n자동 로그인을 하시겠습니까? :[", "Robot의 경고", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                {
                    check.Value = false;
                    return;
                }

                Program.ini.SetIniValue("Login", "Auto", "true");
                Program.ini.SetIniValue("Login", "Save", "true");
                Program.ini.SetIniValue("Login", "Id", Program.id);
                Program.ini.SetIniValue("Login", "Password", Program.password);
            }
            if (check.Value == false)
            {
                Program.ini.SetIniValue("Login", "Auto", "false");
                Program.ini.SetIniValue("Login", "Save", "false");
                Program.ini.SetIniValue("Login", "Id", "");
                Program.ini.SetIniValue("Login", "Password", "");
            }
        }

        private void alarmSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (alarmSwitch.Value == false)
            {
                MainForm.timer.Stop();
            }
            else
            {
                MainForm.timer.Start();
            }
        }

        private void startProgramSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (startProgramSwitch.Value == true)
            {
                MainForm.SetStartup("UnistRobot", true);
            }
            else
            {
                MainForm.SetStartup("UnistRobot", false);
            }
        }
    }
}
