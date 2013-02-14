using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUIControls;

namespace robot
{
    public partial class AlarmForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public class Task
        {
            public string content;
            public int hour;
            public int min;
            public System.Windows.Forms.Timer timer;

            public Task()
            {
                content = "";
                hour = 0;
                min = 0;
            }

            public void timer_Tick(object sender, EventArgs e)
            {
                TaskbarNotifier taskbarNotifier = new TaskbarNotifier();
                taskbarNotifier.SetBackgroundBitmap(new Bitmap(GetType(), "skin.bmp"), Color.FromArgb(255, 0, 255));
                taskbarNotifier.SetCloseBitmap(new Bitmap(GetType(), "close.bmp"), Color.FromArgb(255, 0, 255), new Point(121, 13));
                taskbarNotifier.TitleRectangle = new Rectangle(30, 13, 80, 25);
                taskbarNotifier.ContentRectangle = new Rectangle(12, 30, 125, 72);
                taskbarNotifier.CloseClickable = true;
                taskbarNotifier.TitleClickable = false;
                taskbarNotifier.ContentClickable = true;
                taskbarNotifier.EnableSelectionRectangle = true;
                taskbarNotifier.KeepVisibleOnMousOver = true;
                taskbarNotifier.ReShowOnMouseOver = true;

                taskbarNotifier.Show("알림", content, 500, 3000, 500);

                AlarmForm.taskCount--;
                timer.Stop();
            }
        }

        public static int taskCount;
        
        public AlarmForm()
        {
            InitializeComponent();

            taskCount = 0;
        }

        private void reserveBtn_Click(object sender, EventArgs e)
        {
            if (hourPicker.Value == 0 && minPicker.Value == 0)
            {
                MessageBox.Show("시간을 선택해 주세요 :^|", "Robot의 경고");
                return;
            }
            else if (contentText.Text == "")
            {
                MessageBox.Show("알림 내용을 입력해 주세요 :^|", "Robot의 경고");
                return;
            }
            else
            {
                Task task=new Task();

                task.hour = hourPicker.Value;
                task.min = minPicker.Value;
                task.content = contentText.Text;

                task.timer = new System.Windows.Forms.Timer();
                task.timer.Interval = task.hour * 60 * 60000 + task.min * 60000; //주기 설정
                task.timer.Tick += new EventHandler(task.timer_Tick);
                task.timer.Start();
                this.Visible = false;
            }

            taskCount++;
        }


        private void AlarmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void AlarmForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                contentText.Text = "";
                hourPicker.Value = 0;
                minPicker.Value = 0;

                countLabel.Text = taskCount.ToString() + "개";
                MainForm.alarmFormExist = true;
            }

            else
            {
                MainForm.alarmFormExist = false;
            }
        }
    }
}
