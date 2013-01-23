namespace robot
{
    partial class Form2
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.passBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.saveIdBox = new System.Windows.Forms.CheckBox();
            this.autoLoginBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(163, 35);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(63, 48);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(47, 62);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(100, 21);
            this.passBox.TabIndex = 2;
            this.passBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passBox_KeyDown);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(47, 35);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(100, 21);
            this.idBox.TabIndex = 1;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(12, 66);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(26, 14);
            this.passLabel.TabIndex = 7;
            this.passLabel.Text = "PW";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 38);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(19, 14);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            // 
            // saveIdBox
            // 
            this.saveIdBox.AutoSize = true;
            this.saveIdBox.Location = new System.Drawing.Point(24, 93);
            this.saveIdBox.Name = "saveIdBox";
            this.saveIdBox.Size = new System.Drawing.Size(84, 18);
            this.saveIdBox.TabIndex = 4;
            this.saveIdBox.Text = "아이디 저장";
            this.saveIdBox.UseVisualStyleBackColor = true;
            this.saveIdBox.CheckedChanged += new System.EventHandler(this.saveIdBox_CheckedChanged);
            // 
            // autoLoginBox
            // 
            this.autoLoginBox.AutoSize = true;
            this.autoLoginBox.Enabled = false;
            this.autoLoginBox.Location = new System.Drawing.Point(132, 93);
            this.autoLoginBox.Name = "autoLoginBox";
            this.autoLoginBox.Size = new System.Drawing.Size(84, 18);
            this.autoLoginBox.TabIndex = 5;
            this.autoLoginBox.Text = "자동 로그인";
            this.autoLoginBox.UseVisualStyleBackColor = true;
            this.autoLoginBox.CheckedChanged += new System.EventHandler(this.autoLoginBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NanumGothic", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(54, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "포탈 접속이 필요합니다 :^)";
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(38, 24);
            this.browser.TabIndex = 9;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 120);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoLoginBox);
            this.Controls.Add(this.saveIdBox);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.idLabel);
            this.Font = new System.Drawing.Font("NanumGothic", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.CheckBox saveIdBox;
        private System.Windows.Forms.CheckBox autoLoginBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser browser;
    }
}