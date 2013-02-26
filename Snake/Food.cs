﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace robot.Snake
{
    public class Food
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle foodRec;

        public Food(Random randFood)
        {
            x = randFood.Next(1, 28) * 15;
            y = randFood.Next(1, 28) * 15;

            brush = new SolidBrush(Color.Black);

            width = 15;
            height = 15;

            foodRec = new Rectangle(x, y, width, height);
        }

        public void foodLocation(Random randFood)
        {
            x = randFood.Next(1, 28) * 15;
            y = randFood.Next(1, 28) * 15;
            foodRec.X = x;
            foodRec.Y = y;
        }

        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;

            paper.DrawIcon(new Icon(GetType(), "favicon.ico"), foodRec);
        }
    }
}