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
            this.rankingLabel = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(11, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score :";
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Location = new System.Drawing.Point(116, 209);
            this.statLabel.Name = "statLabel";
            this.statLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statLabel.Size = new System.Drawing.Size(216, 12);
            this.statLabel.TabIndex = 4;
            this.statLabel.Text = "스페이스바를 누르면 재시작 합니다 :^)";
            this.statLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Highest Score : ";
            // 
            // highestScoreLabel
            // 
            this.highestScoreLabel.AutoSize = true;
            this.highestScoreLabel.Location = new System.Drawing.Point(288, 463);
            this.highestScoreLabel.Name = "highestScoreLabel";
            this.highestScoreLabel.Size = new System.Drawing.Size(11, 12);
            this.highestScoreLabel.TabIndex = 6;
            this.highestScoreLabel.Text = "0";
            this.highestScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rankingLabel
            // 
            this.rankingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rankingLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rankingLabel.Location = new System.Drawing.Point(348, 456);
            this.rankingLabel.Name = "rankingLabel";
            this.rankingLabel.Size = new System.Drawing.Size(100, 27);
            this.rankingLabel.TabIndex = 7;
            this.rankingLabel.Text = "View Ranking";
            this.rankingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rankingLabel.Click += new System.EventHandler(this.rankingLabel_Click);
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 483);
            this.Controls.Add(this.rankingLabel);
            this.Controls.Add(this.highestScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.levelLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoboSnake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnakeForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SnakeForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeForm_KeyDown);
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
        private System.Windows.Forms.Label rankingLabel;

    }
}