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
            this.startProgramSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.alarmSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label3 = new System.Windows.Forms.Label();
            this.autoLoginSwitch = new DevComponents.DotNetBar.Controls.SwitchButton();
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
            this.startProgramSwitch.Location = new System.Drawing.Point(149, 12);
            this.startProgramSwitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startProgramSwitch.Name = "startProgramSwitch";
            this.startProgramSwitch.OffText = "끔";
            this.startProgramSwitch.OnText = "켬";
            this.startProgramSwitch.Size = new System.Drawing.Size(66, 28);
            this.startProgramSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.startProgramSwitch.TabIndex = 0;
            this.startProgramSwitch.ValueChanged += new System.EventHandler(this.startProgramSwitch_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "시작 프로그램 등록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
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
            this.alarmSwitch.Location = new System.Drawing.Point(149, 53);
            this.alarmSwitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alarmSwitch.Name = "alarmSwitch";
            this.alarmSwitch.OffText = "끔";
            this.alarmSwitch.OnText = "켬";
            this.alarmSwitch.Size = new System.Drawing.Size(66, 28);
            this.alarmSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.alarmSwitch.TabIndex = 3;
            this.alarmSwitch.Value = true;
            this.alarmSwitch.ValueObject = "Y";
            this.alarmSwitch.ValueChanged += new System.EventHandler(this.alarmSwitch_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
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
            this.autoLoginSwitch.Location = new System.Drawing.Point(149, 96);
            this.autoLoginSwitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.autoLoginSwitch.Name = "autoLoginSwitch";
            this.autoLoginSwitch.OffText = "끔";
            this.autoLoginSwitch.OnText = "켬";
            this.autoLoginSwitch.Size = new System.Drawing.Size(66, 28);
            this.autoLoginSwitch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.autoLoginSwitch.TabIndex = 5;
            this.autoLoginSwitch.Value = true;
            this.autoLoginSwitch.ValueObject = "Y";
            this.autoLoginSwitch.ValueChanged += new System.EventHandler(this.autoLoginSwitch_ValueChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 146);
            this.Controls.Add(this.autoLoginSwitch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.alarmSwitch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startProgramSwitch);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "설정";
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
    }
}