namespace robot.Forms
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.currentUrlLabel = new System.Windows.Forms.TextBox();
            this.bbBtn = new System.Windows.Forms.Button();
            this.portalBtn = new System.Windows.Forms.Button();
            this.libraryBtn = new System.Windows.Forms.Button();
            this.dormBtn = new System.Windows.Forms.Button();
            this.nateClubBtn = new System.Windows.Forms.Button();
            this.mailBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.browser = new ExtendedWebBrowser();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backBtn.ForeColor = System.Drawing.Color.Black;
            this.backBtn.Location = new System.Drawing.Point(2, 0);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(28, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "<";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nextBtn.ForeColor = System.Drawing.Color.Black;
            this.nextBtn.Location = new System.Drawing.Point(36, 0);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(28, 23);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = ">";
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // currentUrlLabel
            // 
            this.currentUrlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentUrlLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.currentUrlLabel.ForeColor = System.Drawing.Color.Black;
            this.currentUrlLabel.Location = new System.Drawing.Point(70, 2);
            this.currentUrlLabel.Name = "currentUrlLabel";
            this.currentUrlLabel.Size = new System.Drawing.Size(967, 21);
            this.currentUrlLabel.TabIndex = 2;
            this.currentUrlLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentUrlLabel_KeyDown);
            // 
            // bbBtn
            // 
            this.bbBtn.Location = new System.Drawing.Point(113, 32);
            this.bbBtn.Name = "bbBtn";
            this.bbBtn.Size = new System.Drawing.Size(105, 23);
            this.bbBtn.TabIndex = 6;
            this.bbBtn.Text = "블랙 보드";
            this.bbBtn.UseVisualStyleBackColor = true;
            this.bbBtn.Click += new System.EventHandler(this.bbBtn_Click);
            // 
            // portalBtn
            // 
            this.portalBtn.Location = new System.Drawing.Point(2, 32);
            this.portalBtn.Name = "portalBtn";
            this.portalBtn.Size = new System.Drawing.Size(105, 23);
            this.portalBtn.TabIndex = 7;
            this.portalBtn.Text = "포탈";
            this.portalBtn.UseVisualStyleBackColor = true;
            this.portalBtn.Click += new System.EventHandler(this.portalBtn_Click);
            // 
            // libraryBtn
            // 
            this.libraryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.libraryBtn.Location = new System.Drawing.Point(224, 32);
            this.libraryBtn.Name = "libraryBtn";
            this.libraryBtn.Size = new System.Drawing.Size(105, 23);
            this.libraryBtn.TabIndex = 8;
            this.libraryBtn.Text = "학정";
            this.libraryBtn.UseVisualStyleBackColor = true;
            this.libraryBtn.Click += new System.EventHandler(this.libraryBtn_Click);
            // 
            // dormBtn
            // 
            this.dormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dormBtn.Location = new System.Drawing.Point(335, 32);
            this.dormBtn.Name = "dormBtn";
            this.dormBtn.Size = new System.Drawing.Size(105, 23);
            this.dormBtn.TabIndex = 9;
            this.dormBtn.Text = "기숙사";
            this.dormBtn.UseVisualStyleBackColor = true;
            this.dormBtn.Click += new System.EventHandler(this.dormBtn_Click);
            // 
            // nateClubBtn
            // 
            this.nateClubBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nateClubBtn.Location = new System.Drawing.Point(557, 32);
            this.nateClubBtn.Name = "nateClubBtn";
            this.nateClubBtn.Size = new System.Drawing.Size(105, 23);
            this.nateClubBtn.TabIndex = 10;
            this.nateClubBtn.Text = "총재 클럽";
            this.nateClubBtn.UseVisualStyleBackColor = true;
            this.nateClubBtn.Click += new System.EventHandler(this.nateClubBtn_Click);
            // 
            // mailBtn
            // 
            this.mailBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mailBtn.Location = new System.Drawing.Point(446, 32);
            this.mailBtn.Name = "mailBtn";
            this.mailBtn.Size = new System.Drawing.Size(105, 23);
            this.mailBtn.TabIndex = 11;
            this.mailBtn.Text = "전자 우편";
            this.mailBtn.UseVisualStyleBackColor = true;
            this.mailBtn.Click += new System.EventHandler(this.mailBtn_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.browser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.Location = new System.Drawing.Point(3, 3);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1016, 560);
            this.browser.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(7, 61);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1030, 592);
            this.tabControl.TabIndex = 12;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged_1);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.mailBtn);
            this.Controls.Add(this.nateClubBtn);
            this.Controls.Add(this.dormBtn);
            this.Controls.Add(this.libraryBtn);
            this.Controls.Add(this.portalBtn);
            this.Controls.Add(this.bbBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.currentUrlLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 681);
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "브라우저";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.tabPage1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.TextBox currentUrlLabel;
        private System.Windows.Forms.Button bbBtn;
        private System.Windows.Forms.Button portalBtn;
        private System.Windows.Forms.Button libraryBtn;
        private System.Windows.Forms.Button dormBtn;
        private System.Windows.Forms.Button nateClubBtn;
        private System.Windows.Forms.Button mailBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private ExtendedWebBrowser browser;
        private System.Windows.Forms.TabControl tabControl;
    }
}