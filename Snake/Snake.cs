using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace robot.Snake
{
    class Snake
    {
        private Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;

        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }

        }

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Black);

            x = 45;
            y = 15;
            width = 15;
            height = 15;

            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 15;
            }
        }

        public void drawSnake(Graphics paper)
        {
            // paper.FillRectangle(new SolidBrush(Color.Black), snakeRec[0]);

            for (int i = 0; i < snakeRec.Length; i++)
            {
                paper.FillRectangle(brush, snakeRec[i]);
            }
        }

        public void drawSnake()
        {
            for (int i = (snakeRec.Length - 1); i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 15;
        }

        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 15;
        }

        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 15;
        }

        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 15;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }
    }
}