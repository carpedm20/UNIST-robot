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
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentBox = new System.Windows.Forms.TextBox();
            this.portalBox = new System.Windows.Forms.ComboBox();
            this.portalList = new System.Windows.Forms.ListBox();
            this.bbList = new System.Windows.Forms.ListBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.settingLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.libraryList = new System.Windows.Forms.ListBox();
            this.studyGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.studyGrid = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomNumberBox = new System.Windows.Forms.ComboBox();
            this.roomNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.studyGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(12, 224);
            this.browser.MinimumSize = new System.Drawing.Size(20, 23);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(810, 483);
            this.browser.TabIndex = 1;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browser_Navigating);
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
            this.portalList.Location = new System.Drawing.Point(14, 36);
            this.portalList.Name = "portalList";
            this.portalList.Size = new System.Drawing.Size(119, 172);
            this.portalList.TabIndex = 10;
            this.portalList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bbList
            // 
            this.bbList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bbList.Enabled = false;
            this.bbList.FormattingEnabled = true;
            this.bbList.ItemHeight = 14;
            this.bbList.Location = new System.Drawing.Point(250, 102);
            this.bbList.Name = "bbList";
            this.bbList.Size = new System.Drawing.Size(110, 46);
            this.bbList.TabIndex = 11;
            this.bbList.Visible = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("NanumGothicExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loadingLabel.Location = new System.Drawing.Point(397, 443);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(56, 28);
            this.loadingLabel.TabIndex = 12;
            this.loadingLabel.Text = "o_o";
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
            this.welcomeLabel.Size = new System.Drawing.Size(151, 14);
            this.welcomeLabel.TabIndex = 16;
            this.welcomeLabel.Text = "이름을 확인 중 입니다  o_O?";
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
            this.libraryList.Location = new System.Drawing.Point(250, 154);
            this.libraryList.Name = "libraryList";
            this.libraryList.Size = new System.Drawing.Size(110, 32);
            this.libraryList.TabIndex = 12;
            this.libraryList.Visible = false;
            this.libraryList.SelectedIndexChanged += new System.EventHandler(this.libraryList_SelectedIndexChanged);
            // 
            // studyGroup
            // 
            this.studyGroup.Controls.Add(this.label7);
            this.studyGroup.Controls.Add(this.groupBox1);
            this.studyGroup.Controls.Add(this.label4);
            this.studyGroup.Controls.Add(this.dateTimePicker1);
            this.studyGroup.Controls.Add(this.label3);
            this.studyGroup.Controls.Add(this.comboBox1);
            this.studyGroup.Controls.Add(this.textBox2);
            this.studyGroup.Controls.Add(this.label2);
            this.studyGroup.Controls.Add(this.textBox1);
            this.studyGroup.Controls.Add(this.label1);
            this.studyGroup.Location = new System.Drawing.Point(150, 32);
            this.studyGroup.Name = "studyGroup";
            this.studyGroup.Size = new System.Drawing.Size(672, 178);
            this.studyGroup.TabIndex = 17;
            this.studyGroup.TabStop = false;
            this.studyGroup.Text = "스터디 룸 예약";
            this.studyGroup.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "예약이 겹칠 경우 예약이 성공하지 못할 수 있습니다 :\'(";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox8);
            this.groupBox1.Controls.Add(this.textBox9);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(312, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 134);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "학생 번호";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(181, 101);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(135, 21);
            this.textBox7.TabIndex = 17;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(181, 74);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(135, 21);
            this.textBox8.TabIndex = 16;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(181, 47);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(135, 21);
            this.textBox9.TabIndex = 15;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(181, 20);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(135, 21);
            this.textBox10.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(21, 101);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(135, 21);
            this.textBox5.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(21, 74);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(135, 21);
            this.textBox6.TabIndex = 12;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 47);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 21);
            this.textBox3.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 14);
            this.label6.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 14);
            this.label5.TabIndex = 10;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(21, 20);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 21);
            this.textBox4.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "예약 날짜";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(86, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "사용 시간";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 시간",
            "2 시간",
            "3 시간"});
            this.comboBox1.Location = new System.Drawing.Point(86, 111);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 22);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(86, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(154, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-mail";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "전화 번호";
            // 
            // studyGrid
            // 
            this.studyGrid.AllowUserToAddRows = false;
            this.studyGrid.AllowUserToDeleteRows = false;
            this.studyGrid.AllowUserToResizeColumns = false;
            this.studyGrid.AllowUserToResizeRows = false;
            this.studyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Column29,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28});
            this.studyGrid.Location = new System.Drawing.Point(14, 250);
            this.studyGrid.MultiSelect = false;
            this.studyGrid.Name = "studyGrid";
            this.studyGrid.ReadOnly = true;
            this.studyGrid.RowHeadersVisible = false;
            this.studyGrid.RowTemplate.Height = 23;
            this.studyGrid.ShowCellErrors = false;
            this.studyGrid.ShowCellToolTips = false;
            this.studyGrid.ShowEditingIcon = false;
            this.studyGrid.ShowRowErrors = false;
            this.studyGrid.Size = new System.Drawing.Size(808, 457);
            this.studyGrid.TabIndex = 18;
            this.studyGrid.Visible = false;
            // 
            // Date
            // 
            this.Date.Frozen = true;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 60;
            // 
            // Column29
            // 
            this.Column29.Frozen = true;
            this.Column29.HeaderText = "0";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Width = 30;
            // 
            // Column6
            // 
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "1";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 30;
            // 
            // Column7
            // 
            this.Column7.Frozen = true;
            this.Column7.HeaderText = "2";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 30;
            // 
            // Column8
            // 
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "3";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 30;
            // 
            // Column9
            // 
            this.Column9.Frozen = true;
            this.Column9.HeaderText = "4";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 30;
            // 
            // Column10
            // 
            this.Column10.Frozen = true;
            this.Column10.HeaderText = "5";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 30;
            // 
            // Column11
            // 
            this.Column11.Frozen = true;
            this.Column11.HeaderText = "6";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 30;
            // 
            // Column12
            // 
            this.Column12.Frozen = true;
            this.Column12.HeaderText = "7";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 30;
            // 
            // Column13
            // 
            this.Column13.Frozen = true;
            this.Column13.HeaderText = "8";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 30;
            // 
            // Column14
            // 
            this.Column14.Frozen = true;
            this.Column14.HeaderText = "9";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 30;
            // 
            // Column15
            // 
            this.Column15.Frozen = true;
            this.Column15.HeaderText = "10";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 30;
            // 
            // Column16
            // 
            this.Column16.Frozen = true;
            this.Column16.HeaderText = "11";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 30;
            // 
            // Column17
            // 
            this.Column17.Frozen = true;
            this.Column17.HeaderText = "12";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 30;
            // 
            // Column18
            // 
            this.Column18.Frozen = true;
            this.Column18.HeaderText = "13";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 30;
            // 
            // Column19
            // 
            this.Column19.Frozen = true;
            this.Column19.HeaderText = "14";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Width = 30;
            // 
            // Column20
            // 
            this.Column20.Frozen = true;
            this.Column20.HeaderText = "15";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Width = 30;
            // 
            // Column21
            // 
            this.Column21.Frozen = true;
            this.Column21.HeaderText = "16";
            this.Column21.Name = "Column21";
            this.Column21.ReadOnly = true;
            this.Column21.Width = 30;
            // 
            // Column22
            // 
            this.Column22.Frozen = true;
            this.Column22.HeaderText = "17";
            this.Column22.Name = "Column22";
            this.Column22.ReadOnly = true;
            this.Column22.Width = 30;
            // 
            // Column23
            // 
            this.Column23.Frozen = true;
            this.Column23.HeaderText = "18";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 30;
            // 
            // Column24
            // 
            this.Column24.Frozen = true;
            this.Column24.HeaderText = "19";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Width = 30;
            // 
            // Column25
            // 
            this.Column25.Frozen = true;
            this.Column25.HeaderText = "20";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 30;
            // 
            // Column26
            // 
            this.Column26.Frozen = true;
            this.Column26.HeaderText = "21";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 30;
            // 
            // Column27
            // 
            this.Column27.Frozen = true;
            this.Column27.HeaderText = "22";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Width = 30;
            // 
            // Column28
            // 
            this.Column28.Frozen = true;
            this.Column28.HeaderText = "23";
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            this.Column28.Width = 30;
            // 
            // roomNumberBox
            // 
            this.roomNumberBox.FormattingEnabled = true;
            this.roomNumberBox.Items.AddRange(new object[] {
            "1 (3-6)",
            "2 (3-6)",
            "3 (3-6)",
            "4 (3-6)",
            "5 (7-12)",
            "6 (3-6)",
            "7 (3-6)",
            "8 (3-6)",
            "9 (3-6)",
            "10 (3-6)"});
            this.roomNumberBox.Location = new System.Drawing.Point(99, 220);
            this.roomNumberBox.Name = "roomNumberBox";
            this.roomNumberBox.Size = new System.Drawing.Size(121, 22);
            this.roomNumberBox.TabIndex = 19;
            this.roomNumberBox.Text = "1 (3-6)";
            this.roomNumberBox.Visible = false;
            this.roomNumberBox.SelectedIndexChanged += new System.EventHandler(this.roomNumberBox_SelectedIndexChanged);
            // 
            // roomNumberLabel
            // 
            this.roomNumberLabel.AutoSize = true;
            this.roomNumberLabel.Location = new System.Drawing.Point(27, 224);
            this.roomNumberLabel.Name = "roomNumberLabel";
            this.roomNumberLabel.Size = new System.Drawing.Size(43, 14);
            this.roomNumberLabel.TabIndex = 14;
            this.roomNumberLabel.Text = "방 번호";
            this.roomNumberLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(834, 725);
            this.Controls.Add(this.roomNumberLabel);
            this.Controls.Add(this.roomNumberBox);
            this.Controls.Add(this.studyGrid);
            this.Controls.Add(this.studyGroup);
            this.Controls.Add(this.libraryList);
            this.Controls.Add(this.portalList);
            this.Controls.Add(this.bbList);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.checkBox1);
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
            this.studyGroup.ResumeLayout(false);
            this.studyGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studyGrid)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label settingLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ListBox libraryList;
        private System.Windows.Forms.GroupBox studyGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView studyGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.ComboBox roomNumberBox;
        private System.Windows.Forms.Label roomNumberLabel;
    }
}

