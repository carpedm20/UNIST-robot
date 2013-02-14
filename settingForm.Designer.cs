namespace robot
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.startProgramSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alarmSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label3 = new System.Windows.Forms.Label();
            this.autoLoginSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.saySwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startProgramSwitch
            // 
            this.startProgramSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.startProgramSwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startProgramSwitch.ForeColor = System.Drawing.Color.Black;
            this.startProgramSwitch.Location = new System.Drawing.Point(149, 129);
            this.startProgramSwitch.Name = "startProgramSwitch";
            this.startProgramSwitch.OffText = "끔";
            this.startProgramSwitch.OnText = "켬";
            this.startProgramSwitch.Size = new System.Drawing.Size(66, 22);
            this.startProgramSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.startProgramSwitch.TabIndex = 0;
            this.startProgramSwitch.Visible = false;
            this.startProgramSwitch.ValueChanged += new System.EventHandler(this.startProgramSwitch_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "시작 프로그램 등록";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "새 글 알리미";
            // 
            // alarmSwitch
            // 
            this.alarmSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.alarmSwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.alarmSwitch.ForeColor = System.Drawing.Color.Black;
            this.alarmSwitch.Location = new System.Drawing.Point(149, 12);
            this.alarmSwitch.Name = "alarmSwitch";
            this.alarmSwitch.OffText = "끔";
            this.alarmSwitch.OnText = "켬";
            this.alarmSwitch.Size = new System.Drawing.Size(66, 22);
            this.alarmSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.alarmSwitch.TabIndex = 3;
            this.alarmSwitch.Value = true;
            this.alarmSwitch.ValueObject = "Y";
            this.alarmSwitch.ValueChanged += new System.EventHandler(this.alarmSwitch_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "자동 로그인";
            // 
            // autoLoginSwitch
            // 
            this.autoLoginSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.autoLoginSwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.autoLoginSwitch.ForeColor = System.Drawing.Color.Black;
            this.autoLoginSwitch.Location = new System.Drawing.Point(149, 51);
            this.autoLoginSwitch.Name = "autoLoginSwitch";
            this.autoLoginSwitch.OffText = "끔";
            this.autoLoginSwitch.OnText = "켬";
            this.autoLoginSwitch.Size = new System.Drawing.Size(66, 22);
            this.autoLoginSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.autoLoginSwitch.TabIndex = 5;
            this.autoLoginSwitch.ValueChanged += new System.EventHandler(this.autoLoginSwitch_ValueChanged);
            // 
            // saySwitch
            // 
            this.saySwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.saySwitch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.saySwitch.ForeColor = System.Drawing.Color.Black;
            this.saySwitch.Location = new System.Drawing.Point(149, 91);
            this.saySwitch.Name = "saySwitch";
            this.saySwitch.OffText = "끔";
            this.saySwitch.OnText = "켬";
            this.saySwitch.Size = new System.Drawing.Size(66, 22);
            this.saySwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.saySwitch.TabIndex = 6;
            this.saySwitch.Value = true;
            this.saySwitch.ValueObject = "Y";
            this.saySwitch.ValueChanged += new System.EventHandler(this.saySwitch_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "랜덤 명언 보이기";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(30, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Created by carpedm20.";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 163);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.saySwitch);
            this.Controls.Add(this.autoLoginSwitch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.alarmSwitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startProgramSwitch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Gulim", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.SwitchButton startProgramSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.SwitchButton alarmSwitch;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.SwitchButton autoLoginSwitch;
        private DevComponents.DotNetBar.Controls.SwitchButton saySwitch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}