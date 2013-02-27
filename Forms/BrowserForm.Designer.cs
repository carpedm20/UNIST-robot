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
            this.components = new System.ComponentModel.Container();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.closeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.닫기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.epBtn = new System.Windows.Forms.Button();
            this.mealBtn = new System.Windows.Forms.Button();
            this.calendarBtn = new System.Windows.Forms.Button();
            this.nightMealBtn = new System.Windows.Forms.Button();
            this.browser = new ExtendedWebBrowser();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.closeMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.currentUrlLabel.Location = new System.Drawing.Point(98, 2);
            this.currentUrlLabel.Name = "currentUrlLabel";
            this.currentUrlLabel.Size = new System.Drawing.Size(897, 21);
            this.currentUrlLabel.TabIndex = 2;
            this.currentUrlLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentUrlLabel_KeyDown);
            // 
            // bbBtn
            // 
            this.bbBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bbBtn.ForeColor = System.Drawing.Color.Black;
            this.bbBtn.Location = new System.Drawing.Point(194, 32);
            this.bbBtn.Name = "bbBtn";
            this.bbBtn.Size = new System.Drawing.Size(90, 23);
            this.bbBtn.TabIndex = 6;
            this.bbBtn.Text = "블랙 보드";
            this.bbBtn.UseVisualStyleBackColor = false;
            this.bbBtn.Click += new System.EventHandler(this.bbBtn_Click);
            // 
            // portalBtn
            // 
            this.portalBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.portalBtn.ForeColor = System.Drawing.Color.Black;
            this.portalBtn.Location = new System.Drawing.Point(2, 32);
            this.portalBtn.Name = "portalBtn";
            this.portalBtn.Size = new System.Drawing.Size(90, 23);
            this.portalBtn.TabIndex = 7;
            this.portalBtn.Text = "포탈";
            this.portalBtn.UseVisualStyleBackColor = false;
            this.portalBtn.Click += new System.EventHandler(this.portalBtn_Click);
            // 
            // libraryBtn
            // 
            this.libraryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.libraryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.libraryBtn.ForeColor = System.Drawing.Color.Black;
            this.libraryBtn.Location = new System.Drawing.Point(290, 32);
            this.libraryBtn.Name = "libraryBtn";
            this.libraryBtn.Size = new System.Drawing.Size(90, 23);
            this.libraryBtn.TabIndex = 8;
            this.libraryBtn.Text = "학정";
            this.libraryBtn.UseVisualStyleBackColor = false;
            this.libraryBtn.Click += new System.EventHandler(this.libraryBtn_Click);
            // 
            // dormBtn
            // 
            this.dormBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dormBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dormBtn.ForeColor = System.Drawing.Color.Black;
            this.dormBtn.Location = new System.Drawing.Point(482, 32);
            this.dormBtn.Name = "dormBtn";
            this.dormBtn.Size = new System.Drawing.Size(90, 23);
            this.dormBtn.TabIndex = 9;
            this.dormBtn.Text = "기숙사";
            this.dormBtn.UseVisualStyleBackColor = false;
            this.dormBtn.Click += new System.EventHandler(this.dormBtn_Click);
            // 
            // nateClubBtn
            // 
            this.nateClubBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nateClubBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nateClubBtn.ForeColor = System.Drawing.Color.Black;
            this.nateClubBtn.Location = new System.Drawing.Point(866, 32);
            this.nateClubBtn.Name = "nateClubBtn";
            this.nateClubBtn.Size = new System.Drawing.Size(90, 23);
            this.nateClubBtn.TabIndex = 10;
            this.nateClubBtn.Text = "총재 클럽";
            this.nateClubBtn.UseVisualStyleBackColor = false;
            this.nateClubBtn.Click += new System.EventHandler(this.nateClubBtn_Click);
            // 
            // mailBtn
            // 
            this.mailBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mailBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mailBtn.ForeColor = System.Drawing.Color.Black;
            this.mailBtn.Location = new System.Drawing.Point(578, 32);
            this.mailBtn.Name = "mailBtn";
            this.mailBtn.Size = new System.Drawing.Size(90, 23);
            this.mailBtn.TabIndex = 11;
            this.mailBtn.Text = "전자 우편";
            this.mailBtn.UseVisualStyleBackColor = false;
            this.mailBtn.Click += new System.EventHandler(this.mailBtn_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.browser);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1022, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.ForeColor = System.Drawing.Color.Black;
            this.tabControl.Location = new System.Drawing.Point(7, 61);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1030, 627);
            this.tabControl.TabIndex = 12;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            this.tabControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // closeMenuStrip
            // 
            this.closeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.닫기ToolStripMenuItem});
            this.closeMenuStrip.Name = "closeMenuStrip";
            this.closeMenuStrip.Size = new System.Drawing.Size(99, 26);
            // 
            // 닫기ToolStripMenuItem
            // 
            this.닫기ToolStripMenuItem.Name = "닫기ToolStripMenuItem";
            this.닫기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.닫기ToolStripMenuItem.Text = "닫기";
            this.닫기ToolStripMenuItem.Click += new System.EventHandler(this.닫기ToolStripMenuItem_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(71, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // epBtn
            // 
            this.epBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.epBtn.ForeColor = System.Drawing.Color.Black;
            this.epBtn.Location = new System.Drawing.Point(98, 32);
            this.epBtn.Name = "epBtn";
            this.epBtn.Size = new System.Drawing.Size(90, 23);
            this.epBtn.TabIndex = 14;
            this.epBtn.Text = "종합정보";
            this.epBtn.UseVisualStyleBackColor = false;
            this.epBtn.Click += new System.EventHandler(this.epBtn_Click);
            // 
            // mealBtn
            // 
            this.mealBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mealBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mealBtn.ForeColor = System.Drawing.Color.Black;
            this.mealBtn.Location = new System.Drawing.Point(386, 32);
            this.mealBtn.Name = "mealBtn";
            this.mealBtn.Size = new System.Drawing.Size(90, 23);
            this.mealBtn.TabIndex = 15;
            this.mealBtn.Text = "주간 식단";
            this.mealBtn.UseVisualStyleBackColor = false;
            this.mealBtn.Click += new System.EventHandler(this.mealBtn_Click);
            // 
            // calendarBtn
            // 
            this.calendarBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.calendarBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.calendarBtn.ForeColor = System.Drawing.Color.Black;
            this.calendarBtn.Location = new System.Drawing.Point(674, 32);
            this.calendarBtn.Name = "calendarBtn";
            this.calendarBtn.Size = new System.Drawing.Size(90, 23);
            this.calendarBtn.TabIndex = 16;
            this.calendarBtn.Text = "학사 일정";
            this.calendarBtn.UseVisualStyleBackColor = false;
            this.calendarBtn.Click += new System.EventHandler(this.calendarBtn_Click);
            // 
            // nightMealBtn
            // 
            this.nightMealBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightMealBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nightMealBtn.ForeColor = System.Drawing.Color.Black;
            this.nightMealBtn.Location = new System.Drawing.Point(770, 32);
            this.nightMealBtn.Name = "nightMealBtn";
            this.nightMealBtn.Size = new System.Drawing.Size(90, 23);
            this.nightMealBtn.TabIndex = 17;
            this.nightMealBtn.Text = "야식 정보";
            this.nightMealBtn.UseVisualStyleBackColor = false;
            this.nightMealBtn.Click += new System.EventHandler(this.nightMealBtn_Click);
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.Location = new System.Drawing.Point(3, 3);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1016, 595);
            this.browser.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1041, 696);
            this.Controls.Add(this.nightMealBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.calendarBtn);
            this.Controls.Add(this.mealBtn);
            this.Controls.Add(this.epBtn);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.nateClubBtn);
            this.Controls.Add(this.portalBtn);
            this.Controls.Add(this.mailBtn);
            this.Controls.Add(this.dormBtn);
            this.Controls.Add(this.libraryBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.bbBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.currentUrlLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 681);
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robrowser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrowserForm_FormClosing);
            this.tabPage1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.closeMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip closeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 닫기ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button epBtn;
        private System.Windows.Forms.Button mealBtn;
        private System.Windows.Forms.Button calendarBtn;
        private System.Windows.Forms.Button nightMealBtn;
    }
}