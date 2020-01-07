using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Field
    {
        private int _height;
        private int _width;

        private int _xGate;
        private int _yGate;
        private int _heightGate;



        public Field(int height, int width, int xG = 20, int yG = 20 , int heightGate = 60)
        {
            _height = height;
            _width = width;
            _heightGate = heightGate;
            _xGate = xG;
            _yGate = yG;
        }
        public int Height
        {
            get => _height;
        }

        public int Width
        {
            get => _width;
        }
        public int XGate { get => _xGate; set => _xGate = value; }
        public int YGate { get => _yGate; set => _yGate = value; }
        public int HeightGate { get => _heightGate; set => _heightGate = value; }

        public bool isGoal (int x, int y)
        {
            if (x<=_xGate && y>=_yGate && y<= _yGate + _heightGate)
            {
                return true;
            }
            return false;
        }
    }
}
