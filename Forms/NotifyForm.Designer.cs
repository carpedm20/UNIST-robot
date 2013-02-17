namespace robot
{
    partial class AlarmForm
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
            this.contentText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reserveBtn = new System.Windows.Forms.Button();
            this.hourPicker = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.minPicker = new DevComponents.Editors.IntegerInput();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hourPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPicker)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentText
            // 
            this.contentText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contentText.ForeColor = System.Drawing.Color.Black;
            this.contentText.Location = new System.Drawing.Point(14, 84);
            this.contentText.Multiline = true;
            this.contentText.Name = "contentText";
            this.contentText.Size = new System.Drawing.Size(228, 77);
            this.contentText.TabIndex = 3;
            this.contentText.Text = "여러분의 할 일을 잊지 않도록\r\n \r\n알림을 예약해 두세요 :^)";
            this.contentText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contentText_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "알림 내용";
            // 
            // reserveBtn
            // 
            this.reserveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.reserveBtn.ForeColor = System.Drawing.Color.Black;
            this.reserveBtn.Location = new System.Drawing.Point(167, 169);
            this.reserveBtn.Name = "reserveBtn";
            this.reserveBtn.Size = new System.Drawing.Size(75, 26);
            this.reserveBtn.TabIndex = 4;
            this.reserveBtn.Text = "예약";
            this.reserveBtn.UseVisualStyleBackColor = false;
            this.reserveBtn.Click += new System.EventHandler(this.reserveBtn_Click);
            // 
            // hourPicker
            // 
            this.hourPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.hourPicker.BackgroundStyle.Class = "DateTimeInputBackground";
            this.hourPicker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.hourPicker.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.hourPicker.ForeColor = System.Drawing.Color.Black;
            this.hourPicker.Location = new System.Drawing.Point(10, 20);
            this.hourPicker.MaxValue = 100;
            this.hourPicker.MinValue = 0;
            this.hourPicker.Name = "hourPicker";
            this.hourPicker.ShowUpDown = true;
            this.hourPicker.Size = new System.Drawing.Size(63, 21);
            this.hourPicker.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(79, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "시간";
            // 
            // minPicker
            // 
            this.minPicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.minPicker.BackgroundStyle.Class = "DateTimeInputBackground";
            this.minPicker.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.minPicker.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.minPicker.ForeColor = System.Drawing.Color.Black;
            this.minPicker.Location = new System.Drawing.Point(114, 20);
            this.minPicker.MaxValue = 59;
            this.minPicker.MinValue = 0;
            this.minPicker.Name = "minPicker";
            this.minPicker.ShowUpDown = true;
            this.minPicker.Size = new System.Drawing.Size(63, 21);
            this.minPicker.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(183, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "분 후";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.minPicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.hourPicker);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "알림 시간";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(22, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "대기 중 알림 : ";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.countLabel.ForeColor = System.Drawing.Color.Black;
            this.countLabel.Location = new System.Drawing.Point(112, 177);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(27, 12);
            this.countLabel.TabIndex = 12;
            this.countLabel.Text = "0 개";
            // 
            // AlarmForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(257, 208);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reserveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contentText);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "개인 알림";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.AlarmForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.hourPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minPicker)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button reserveBtn;
        private DevComponents.Editors.IntegerInput hourPicker;
        private System.Windows.Forms.Label label3;
        private DevComponents.Editors.IntegerInput minPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label countLabel;



    }
}