namespace robot.Snake
{
    partial class SnakeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnakeForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.levelLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.highestScoreLabel = new System.Windows.Forms.Label();
            this.eatRobotLabel = new System.Windows.Forms.Label();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverScoreLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.levelLabel.ForeColor = System.Drawing.Color.Black;
            this.levelLabel.Location = new System.Drawing.Point(54, 463);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(11, 12);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "0";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scoreLabel.ForeColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(146, 463);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(11, 12);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(100, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score :";
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.statLabel.ForeColor = System.Drawing.Color.Black;
            this.statLabel.Location = new System.Drawing.Point(136, 209);
            this.statLabel.Name = "statLabel";
            this.statLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statLabel.Size = new System.Drawing.Size(177, 12);
            this.statLabel.TabIndex = 4;
            this.statLabel.Text = "Press Space Bar to Restart :^)";
            this.statLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(196, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Highest Score : ";
            // 
            // highestScoreLabel
            // 
            this.highestScoreLabel.AutoSize = true;
            this.highestScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.highestScoreLabel.ForeColor = System.Drawing.Color.Black;
            this.highestScoreLabel.Location = new System.Drawing.Point(288, 463);
            this.highestScoreLabel.Name = "highestScoreLabel";
            this.highestScoreLabel.Size = new System.Drawing.Size(11, 12);
            this.highestScoreLabel.TabIndex = 6;
            this.highestScoreLabel.Text = "0";
            this.highestScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // eatRobotLabel
            // 
            this.eatRobotLabel.AutoSize = true;
            this.eatRobotLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.eatRobotLabel.ForeColor = System.Drawing.Color.Black;
            this.eatRobotLabel.Location = new System.Drawing.Point(185, 209);
            this.eatRobotLabel.Name = "eatRobotLabel";
            this.eatRobotLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eatRobotLabel.Size = new System.Drawing.Size(78, 12);
            this.eatRobotLabel.TabIndex = 8;
            this.eatRobotLabel.Text = "Eat Robot :-)";
            this.eatRobotLabel.Visible = false;
            // 
            // browser
            // 
            this.browser.Location = new System.Drawing.Point(373, 35);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(64, 42);
            this.browser.TabIndex = 9;
            this.browser.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 482);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Save Score to Server";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(196, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "Server Score : ";
            // 
            // serverScoreLabel
            // 
            this.serverScoreLabel.AutoSize = true;
            this.serverScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.serverScoreLabel.ForeColor = System.Drawing.Color.Black;
            this.serverScoreLabel.Location = new System.Drawing.Point(288, 483);
            this.serverScoreLabel.Name = "serverScoreLabel";
            this.serverScoreLabel.Size = new System.Drawing.Size(11, 12);
            this.serverScoreLabel.TabIndex = 12;
            this.serverScoreLabel.Text = "0";
            this.serverScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 13;
            this.button1.Text = "View Ranking";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.rankingLabel_Click);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 501);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serverScoreLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.eatRobotLabel);
            this.Controls.Add(this.highestScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.levelLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoboSnake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnakeForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.SnakeForm_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnakeForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label highestScoreLabel;
        private System.Windows.Forms.Label eatRobotLabel;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label serverScoreLabel;
        private System.Windows.Forms.Button button1;

    }
}