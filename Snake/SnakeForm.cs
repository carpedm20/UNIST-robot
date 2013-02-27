using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace robot.Snake
{
    public partial class SnakeForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        Graphics paper;
        Snake snake = new Snake();
        bool down, up, right, left;
        Random randFood = new Random();
        List<int> passedScore;
        Food food;
        List<Food> unFood;

        bool isStart = false;
        bool keydEnabled = true;
        bool saveToServer = false;

        public static bool isRakingFormExist = false;

        static public Point snakeHeadPos;

        int score = 0;
        int highestScore = 0;

        SnakeRankingForm rankingForm;

        public SnakeForm()
        {
            InitializeComponent();
            KeyPreview = true;

            eatRobotLabel.Visible = true;

            food = new Food(randFood, false);

            unFood = new List<Food>();

            passedScore = new List<int>();

            down = false;
            up = false;
            right = false;
            left = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space && isStart == false)
            {
                restart();
            }

            if (keydEnabled == false)
                return true;

            if (keyData == Keys.Down && up == false)
            {
                eatRobotLabel.Visible = false;

                down = true;
                up = false;
                right = false;
                left = false;
            }

            if (keyData == Keys.Up && down == false)
            {
                eatRobotLabel.Visible = false;

                down = false;
                up = true;
                right = false;
                left = false;
            }

            if (keyData == Keys.Right && left == false)
            {
                eatRobotLabel.Visible = false;

                down = false;
                up = false;
                right = true;
                left = false;
            }

            if (keyData == Keys.Left && right == false)
            {
                eatRobotLabel.Visible = false;

                down = false;
                up = false;
                right = false;
                left = true;
            }

            keydEnabled = false;
            return true;
        }

        private void SnakeForm_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);

            if (!snake.SnakeRec[0].IntersectsWith(food.foodRec))
            {
                food.drawFood(paper);

                foreach (Food fl in unFood)
                {
                    fl.drawFood(paper);
                }
            }

            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    snakeHeadPos = snake.SnakeRec[i].Location;
                    snake.growSnake();
                    food.foodLocation(randFood, unFood);
                }
            }

            Rectangle[] snakeRec = new Rectangle[29];
            SolidBrush brush = new SolidBrush(Color.Gray);

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(0, i * 15, 15, 15);
            }

            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(15 * 29, i * 15, 15, 15);
            }

            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(i * 15, 0, 15, 15);
            }

            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(i * 15, 15 * 29, 15, 15);
            }

            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }

            snakeRec[0] = new Rectangle(29 * 15, 15 * 29, 15, 15);
            paper.FillRectangle(brush, snakeRec[0]);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score % 50 == 0 && score != 0)
            {
                bool isPassed = false;

                foreach(int s in passedScore) 
                {
                    if (s == score)
                    {
                        isPassed = true;
                        break;
                    }
                }

                if (isPassed == false)
                {
                    passedScore.Add(score);
                    timer1.Interval = timer1.Interval * 9 / 10;
                    levelLabel.Text = (score / 50).ToString();

                    Food f = new Food(randFood, true);
                    unFood.Add(f);
                }
            }

            keydEnabled = true;

            if (down) { snake.moveDown(); }
            else if (up) { snake.moveUp(); }
            else if (right) { snake.moveRight(); }
            else if (left) { snake.moveLeft(); }

            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    snakeHeadPos = snake.SnakeRec[i].Location;
                    snake.growSnake();
                    score += 10;
                    scoreLabel.Text = score.ToString();
                    food.foodLocation(randFood, unFood);
                }
            }

            collision();

            this.Invalidate();
        }

        public void collision()
        {
            for (int i = 1; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    timer1.Stop();
                    MessageBox.Show("snake is dead :(");

                    isStart = false;
                    statLabel.Visible = true;

                    if (highestScore < score)
                    {
                        highestScore = score;
                        highestScoreLabel.Text = highestScore.ToString();
                    }

                    if (saveToServer == true)
                    {
                        string url = "http://carpedm20.net76.net/snake_insert_auto.php?name=" + Program.id + "&score=" + highestScore;
                        browser.Navigate(url);

                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                        }

                        url = "http://carpedm20.net76.net/snake_highest.php?name=" + Program.id;
                        browser.Navigate(url);

                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                        }

                        serverScoreLabel.Text = browser.Document.Body.InnerText;

                        if (rankingForm != null)
                        {
                            rankingForm.getScore();
                            rankingForm.setScore(highestScore);
                        }
                    }
                }
            }

            foreach (Food fl in unFood)
            {
                if (snake.SnakeRec[0].IntersectsWith(fl.foodRec))
                {
                    timer1.Stop();
                    MessageBox.Show("snake is dead :(");

                    isStart = false;
                    statLabel.Visible = true;

                    if (highestScore < score)
                    {
                        highestScore = score;
                        highestScoreLabel.Text = highestScore.ToString();
                    }

                    if (saveToServer == true)
                    {
                        string url = "http://carpedm20.net76.net/snake_insert_auto.php?name=" + Program.id + "&score=" + highestScore;
                        browser.Navigate(url);

                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                        }

                        url = "http://carpedm20.net76.net/snake_highest.php?name=" + Program.id;
                        browser.Navigate(url);

                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                        }

                        serverScoreLabel.Text = browser.Document.Body.InnerText;

                        if (rankingForm != null)
                        {
                            rankingForm.getScore();
                            rankingForm.setScore(highestScore);
                        }
                    }
                }
            }

            if (snake.SnakeRec[0].X < 15 || snake.SnakeRec[0].X > 420)
            {
                timer1.Stop();
                MessageBox.Show("snake is dead :(");

                isStart = false;
                statLabel.Visible = true;

                if (highestScore < score)
                {
                    highestScore = score;
                    highestScoreLabel.Text = highestScore.ToString();
                }

                if (saveToServer == true)
                {
                    string url = "http://carpedm20.net76.net/snake_insert_auto.php?name=" + Program.id + "&score=" + highestScore;
                    browser.Navigate(url);

                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }

                    url = "http://carpedm20.net76.net/snake_highest.php?name=" + Program.id;
                    browser.Navigate(url);

                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }

                    serverScoreLabel.Text = browser.Document.Body.InnerText;

                    if (rankingForm != null)
                    {
                        rankingForm.getScore();
                        rankingForm.setScore(highestScore);
                    }
                }
            }

            if (snake.SnakeRec[0].Y < 15 || snake.SnakeRec[0].Y > 420)
            {
                timer1.Stop();
                MessageBox.Show("snake is dead :(");

                isStart = false;
                statLabel.Visible = true;

                if (highestScore < score)
                {
                    highestScore = score;
                    highestScoreLabel.Text = highestScore.ToString();
                }

                if (saveToServer == true)
                {
                    string url = "http://carpedm20.net76.net/snake_insert_auto.php?name=" + Program.id + "&score=" + highestScore;
                    browser.Navigate(url);

                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }

                    url = "http://carpedm20.net76.net/snake_highest.php?name=" + Program.id;
                    browser.Navigate(url);

                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }

                    serverScoreLabel.Text = browser.Document.Body.InnerText;

                    if (rankingForm != null)
                    {
                        rankingForm.getScore();
                        rankingForm.setScore(highestScore);
                    }
                }
            }
        }

        private void restart()
        {
            isStart = true;
            statLabel.Visible = false;

            timer1.Start();

            snake = new Snake();
            food = new Food(randFood, false);
            unFood = new List<Food>();
            snake = new Snake();
            passedScore = new List<int>();

            score = 0;
            scoreLabel.Text = "0";
            levelLabel.Text = "0";
            timer1.Interval = 200;

            down = false;
            up = false;
            right = false;
            left = false;
        }

        private void rankingLabel_Click(object sender, EventArgs e)
        {
            if (isRakingFormExist == true)
            {
                MessageBox.Show("Ranking is aleady displayed :-(", "Robot's Warning");
                return;
            }

            isRakingFormExist = true;

            rankingForm = new SnakeRankingForm(this.Location, highestScore);
            rankingForm.StartPosition = FormStartPosition.Manual;

            rankingForm.Location = new Point(this.Location.X + 480, this.Location.Y);

            rankingForm.Show();
        }

        private void SnakeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.isExiting == false)
            {
                restart();
                this.Visible = false;
                e.Cancel = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                saveToServer = true;
            }

            else
            {
                saveToServer = false;
            }
        }

        private void SnakeForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                string url = "http://carpedm20.net76.net/snake_highest.php?name=" + Program.id;
                browser.Navigate(url);

                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                serverScoreLabel.Text = browser.Document.Body.InnerText;
                eatRobotLabel.Visible = true;
            }
        }
    }
}
