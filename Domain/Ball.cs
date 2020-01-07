using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Ball
    {
        private int _ballWidth;
        private int _ballHeight;

        public Ball(int BallWidth, int BallHeight)
        {
            _ballWidth = BallWidth;
            _ballHeight = BallHeight;
        }

        public int Width
        {
            get => _ballWidth;
        }

        public int Height
        {
            get => _ballHeight;
        }

        public int x;
        public int y;
        public int VelX;
        public int VelY;
    }
}
