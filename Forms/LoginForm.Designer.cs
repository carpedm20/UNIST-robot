namespace robot
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginBtn = new System.Windows.Forms.Button();
            this.passText = new System.Windows.Forms.TextBox();
            this.idText = new System.Windows.Forms.TextBox();
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
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.loginBtn.ForeColor = System.Drawing.Color.Black;
            this.loginBtn.Location = new System.Drawing.Point(164, 36);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(63, 51);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passText
            // 
            this.passText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.passText.ForeColor = System.Drawing.Color.Black;
            this.passText.Location = new System.Drawing.Point(47, 66);
            this.passText.Name = "passText";
            this.passText.PasswordChar = '*';
            this.passText.Size = new System.Drawing.Size(100, 21);
            this.passText.TabIndex = 2;
            this.passText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passBox_KeyDown);
            // 
            // idText
            // 
            this.idText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.idText.ForeColor = System.Drawing.Color.Black;
            this.idText.Location = new System.Drawing.Point(47, 36);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(100, 21);
            this.idText.TabIndex = 1;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.passLabel.ForeColor = System.Drawing.Color.Black;
            this.passLabel.Location = new System.Drawing.Point(12, 70);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(23, 12);
            this.passLabel.TabIndex = 7;
            this.passLabel.Text = "PW";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.idLabel.ForeColor = System.Drawing.Color.Black;
            this.idLabel.Location = new System.Drawing.Point(12, 39);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(16, 12);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            // 
            // saveIdBox
            // 
            this.saveIdBox.AutoSize = true;
            this.saveIdBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.saveIdBox.ForeColor = System.Drawing.Color.Black;
            this.saveIdBox.Location = new System.Drawing.Point(27, 104);
            this.saveIdBox.Name = "saveIdBox";
            this.saveIdBox.Size = new System.Drawing.Size(88, 16);
            this.saveIdBox.TabIndex = 4;
            this.saveIdBox.Text = "아이디 저장";
            this.saveIdBox.UseVisualStyleBackColor = false;
            this.saveIdBox.CheckedChanged += new System.EventHandler(this.saveIdBox_CheckedChanged);
            // 
            // autoLoginBox
            // 
            this.autoLoginBox.AutoSize = true;
            this.autoLoginBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.autoLoginBox.Enabled = false;
            this.autoLoginBox.ForeColor = System.Drawing.Color.Black;
            this.autoLoginBox.Location = new System.Drawing.Point(135, 104);
            this.autoLoginBox.Name = "autoLoginBox";
            this.autoLoginBox.Size = new System.Drawing.Size(88, 16);
            this.autoLoginBox.TabIndex = 5;
            this.autoLoginBox.Text = "자동 로그인";
            this.autoLoginBox.UseVisualStyleBackColor = false;
            this.autoLoginBox.CheckedChanged += new System.EventHandler(this.autoLoginBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Gulim", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "포탈 접속이 필요합니다 :^)";
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(0, 0);
            this.browser.MinimumSize = new System.Drawing.Size(20, 17);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(38, 21);
            this.browser.TabIndex = 9;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(239, 130);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoLoginBox);
            this.Controls.Add(this.saveIdBox);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.idText);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.idLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.CheckBox saveIdBox;
        private System.Windows.Forms.CheckBox autoLoginBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser browser;
    }
}