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

        bool isStart = false;
        bool keydEnabled = true;
        int score = 0;
        int highestScore = 0;

        public SnakeForm()
        {
            InitializeComponent();
            food = new Food(randFood);

            passedScore = new List<int>();

            down = false;
            up = false;
            right = false;
            left = false;
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space && isStart == false)
            {
                restart(sender, e);
            }

            if (keydEnabled == false)
                return;

            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }

            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }

            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }

            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }

            keydEnabled = false;
        }

        private void SnakeForm_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);

            if (!snake.SnakeRec[0].IntersectsWith(food.foodRec))
                food.drawFood(paper);

            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    snake.growSnake();
                    food.foodLocation(randFood);
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
                    timer1.Interval = timer1.Interval * 4 / 5;
                    levelLabel.Text = (score / 50).ToString();
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
                    snake.growSnake();
                    score += 10;
                    scoreLabel.Text = score.ToString();
                    food.foodLocation(randFood);
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
            }
        }

        private void restart(object sender, EventArgs e)
        {
            isStart = true;
            statLabel.Visible = false;

            timer1.Start();

            snake = new Snake();
            food = new Food(randFood);
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
            SnakeRankingForm rankingForm = new SnakeRankingForm(highestScore);
            rankingForm.Show();
        }

        private void SnakeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainForm.isExiting == false)
            {
                this.Visible = false;
                e.Cancel = true;
            }
        }
    }
}
