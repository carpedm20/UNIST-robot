namespace robot
{
    partial class Form1
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
            this.browser = new System.Windows.Forms.WebBrowser();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.contentBox = new System.Windows.Forms.TextBox();
            this.portalBox = new System.Windows.Forms.ComboBox();
            this.portalList = new System.Windows.Forms.ListBox();
            this.bbList = new System.Windows.Forms.ListBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.libraryList = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.settingLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(12, 230);
            this.browser.MinimumSize = new System.Drawing.Size(20, 23);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(810, 477);
            this.browser.TabIndex = 1;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            this.browser.VisibleChanged += new System.EventHandler(this.browser_VisibleChanged);
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.gridView.Enabled = false;
            this.gridView.Location = new System.Drawing.Point(150, 32);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowHeadersWidth = 30;
            this.gridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.ShowCellErrors = false;
            this.gridView.ShowCellToolTips = false;
            this.gridView.ShowEditingIcon = false;
            this.gridView.ShowRowErrors = false;
            this.gridView.Size = new System.Drawing.Size(672, 178);
            this.gridView.TabIndex = 2;
            this.gridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellClick);
            this.gridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellContentClick);
            // 
            // contentBox
            // 
            this.contentBox.Location = new System.Drawing.Point(12, 250);
            this.contentBox.Multiline = true;
            this.contentBox.Name = "contentBox";
            this.contentBox.Size = new System.Drawing.Size(76, 53);
            this.contentBox.TabIndex = 8;
            this.contentBox.Visible = false;
            // 
            // portalBox
            // 
            this.portalBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portalBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.portalBox.FormattingEnabled = true;
            this.portalBox.Items.AddRange(new object[] {
            "학사 공지",
            "전체 공지",
            "대학원 공지",
            "최신 게시물",
            "개선 및 제안",
            "Q & A"});
            this.portalBox.Location = new System.Drawing.Point(150, 216);
            this.portalBox.Name = "portalBox";
            this.portalBox.Size = new System.Drawing.Size(103, 22);
            this.portalBox.TabIndex = 3;
            this.portalBox.Visible = false;
            this.portalBox.SelectedIndexChanged += new System.EventHandler(this.boardBox_SelectedIndexChanged);
            // 
            // portalList
            // 
            this.portalList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.portalList.Enabled = false;
            this.portalList.FormattingEnabled = true;
            this.portalList.ItemHeight = 14;
            this.portalList.Items.AddRange(new object[] {
            "학사 공지",
            "전체 공지",
            "대학원 공지",
            "최신 게시물"});
            this.portalList.Location = new System.Drawing.Point(6, 20);
            this.portalList.Name = "portalList";
            this.portalList.Size = new System.Drawing.Size(110, 60);
            this.portalList.TabIndex = 10;
            this.portalList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bbList
            // 
            this.bbList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bbList.Enabled = false;
            this.bbList.FormattingEnabled = true;
            this.bbList.ItemHeight = 14;
            this.bbList.Location = new System.Drawing.Point(6, 86);
            this.bbList.Name = "bbList";
            this.bbList.Size = new System.Drawing.Size(110, 46);
            this.bbList.TabIndex = 11;
            this.bbList.SelectedIndexChanged += new System.EventHandler(this.bbList_SelectedIndexChanged);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("NanumGothicExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loadingLabel.Location = new System.Drawing.Point(349, 474);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(126, 28);
            this.loadingLabel.TabIndex = 12;
            this.loadingLabel.Text = "로딩 중...:)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.libraryList);
            this.groupBox1.Controls.Add(this.portalList);
            this.groupBox1.Controls.Add(this.bbList);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 178);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // libraryList
            // 
            this.libraryList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.libraryList.Enabled = false;
            this.libraryList.FormattingEnabled = true;
            this.libraryList.ItemHeight = 14;
            this.libraryList.Items.AddRange(new object[] {
            "도서 검색",
            "스터디룸 예약",
            "열람실 좌석 현황"});
            this.libraryList.Location = new System.Drawing.Point(6, 140);
            this.libraryList.Name = "libraryList";
            this.libraryList.Size = new System.Drawing.Size(110, 32);
            this.libraryList.TabIndex = 12;
            this.libraryList.SelectedIndexChanged += new System.EventHandler(this.libraryList_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 18);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "자동 로그인";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.Location = new System.Drawing.Point(793, 10);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(29, 14);
            this.settingLabel.TabIndex = 15;
            this.settingLabel.Text = "설정";
            this.settingLabel.Click += new System.EventHandler(this.settingLabel_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(166, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(0, 14);
            this.welcomeLabel.TabIndex = 16;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 33;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "제목";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 430;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "작성자";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "작성일";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "조회수";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(834, 725);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.portalBox);
            this.Controls.Add(this.contentBox);
            this.Controls.Add(this.gridView);
            this.Font = new System.Drawing.Font("NanumGothic", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot";
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.TextBox contentBox;
        private System.Windows.Forms.ComboBox portalBox;
        private System.Windows.Forms.ListBox portalList;
        private System.Windows.Forms.ListBox bbList;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label settingLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ListBox libraryList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

