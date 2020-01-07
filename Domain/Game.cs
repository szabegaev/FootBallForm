using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Game
    {
        public Field MainField;
        public List<Ball> BallsA;
        public List<Ball> BallsB;

        public Game(int heightField, int widthField, int countballs, int BallHeight ,int BallWidth)
        {
            MainField = new Field(heightField, widthField);
            BallsA = new List<Ball>();
            BallsB = new List<Ball>();

            Random random = new Random();

            for (int i = 0; i < countballs; i++)
            {
                BallsA.Add(CreateBall(random, BallHeight, BallWidth));
                BallsB.Add(CreateBall(random, BallHeight, BallWidth));
            }
           
        }        
        private Ball CreateBall(Random random, int BallHeight, int BallWidth)
        {
            Ball b = new Ball(BallHeight, BallWidth);
            b.y = random.Next(0, MainField.Height - b.Height);
            b.x = random.Next(0, MainField.Width - b.Width);
            b.VelX = random.Next(1, 10);
            b.VelY = random.Next(1, 10);
            return b;
        }

        public int KollGoal(List<Ball> Balls)
        {
            var kolGoal = 0;

            foreach (var ball in Balls)
            {
                if (MainField.isGoal(ball.x, ball.y))
                {
                    kolGoal++;
                }
            }

            return kolGoal;
        }
        public void UpdateBalls()
        {
            UpdateBalls(BallsA);
            UpdateBalls(BallsB);
        }

        public void UpdateBalls(List<Ball> Balls)
        {
            foreach (var item in Balls)
            {
                UpdateBall(item);
            }
        }

        private void UpdateBall(Ball ball)
        {
            ball.x += ball.VelX;
            if (ball.x < 0)
            {
                ball.VelX = -ball.VelX;
            }
            else if (ball.x + ball.Width > MainField.Width)
            {
                ball.VelX = -ball.VelX;
            }

            ball.y += ball.VelY;
            if (ball.y < 0)
            {
                ball.VelY = -ball.VelY;
            }
            else if (ball.y + ball.Height > MainField.Height)
            {
                ball.VelY = -ball.VelY;
            }
        }
    }
}
