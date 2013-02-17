namespace robot
{
    partial class MailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailForm));
            this.contentText = new System.Windows.Forms.TextBox();
            this.sendBox = new System.Windows.Forms.Button();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.toBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // contentText
            // 
            this.contentText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.contentText.ForeColor = System.Drawing.Color.Black;
            this.contentText.Location = new System.Drawing.Point(12, 55);
            this.contentText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contentText.Multiline = true;
            this.contentText.Name = "contentText";
            this.contentText.Size = new System.Drawing.Size(261, 140);
            this.contentText.TabIndex = 3;
            this.contentText.Text = "carpedm20@gmail.com 으로\r\n\r\n버그, 건의 사항 및 기타 의견을 보내주세요~\r\n\r\n여러분의 의견, 언제나 환영합니다 :)";
            this.contentText.TextChanged += new System.EventHandler(this.contentText_TextChanged);
            this.contentText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contentText_KeyDown);
            // 
            // sendBox
            // 
            this.sendBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sendBox.ForeColor = System.Drawing.Color.Black;
            this.sendBox.Location = new System.Drawing.Point(198, 202);
            this.sendBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sendBox.Name = "sendBox";
            this.sendBox.Size = new System.Drawing.Size(75, 29);
            this.sendBox.TabIndex = 1;
            this.sendBox.Text = "보내기";
            this.sendBox.UseVisualStyleBackColor = false;
            this.sendBox.Click += new System.EventHandler(this.sendBox_Click);
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fromLabel.ForeColor = System.Drawing.Color.Black;
            this.fromLabel.Location = new System.Drawing.Point(12, 5);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(46, 12);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "From : ";
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toLabel.ForeColor = System.Drawing.Color.Black;
            this.toLabel.Location = new System.Drawing.Point(12, 32);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(32, 12);
            this.toLabel.TabIndex = 3;
            this.toLabel.Text = "To : ";
            // 
            // toBox
            // 
            this.toBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toBox.ForeColor = System.Drawing.Color.Black;
            this.toBox.Location = new System.Drawing.Point(50, 27);
            this.toBox.Name = "toBox";
            this.toBox.Size = new System.Drawing.Size(223, 21);
            this.toBox.TabIndex = 2;
            this.toBox.Text = "carpedm20@gmail.com";
            this.toBox.TextChanged += new System.EventHandler(this.toBox_TextChanged);
            // 
            // MailForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(285, 239);
            this.Controls.Add(this.toBox);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.sendBox);
            this.Controls.Add(this.contentText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Gulim", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "메일";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MailForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.MailForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox contentText;
        private System.Windows.Forms.Button sendBox;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.TextBox toBox;
    }
}