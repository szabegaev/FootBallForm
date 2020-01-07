using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootBallForm
{
    public partial class Form1 : Form
    {
        public int heightField = 500;
        public int widthField = 800;
        private int Countballs = 5;
        private int BallWidth = 30;
        private int BallHeight = 30;

        private int CountGoalA = 0;
        private int CountGoalB = 0;

        Game game;

        public Form1()
        {           
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(heightField, widthField, Countballs, BallHeight, BallWidth);

            var xGate = 20;
            var yGate = 6 * heightField / 10;
            var _heightGate = heightField / 5;

            game.MainField.XGate = xGate;
            game.MainField.YGate = yGate;
            game.MainField.HeightGate = _heightGate;

            // Use double buffering to reduce flicker.
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }
        // Draw the ball at its current location.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);

            int yGate = game.MainField.YGate;
            int xGate = game.MainField.XGate;
            int _heightGate = game.MainField.HeightGate;

            e.Graphics.DrawLine(new Pen(Color.Red, 10), 0, yGate, xGate, yGate);            
            e.Graphics.DrawLine(new Pen(Color.Red, 10), 0, yGate - _heightGate, xGate, yGate - _heightGate);
            e.Graphics.DrawLine(new Pen(Color.Red, 2), xGate, yGate, xGate, yGate - _heightGate);

            e.Graphics.DrawLine(new Pen(Color.Blue, 10), widthField- xGate, yGate, widthField, yGate);
            e.Graphics.DrawLine(new Pen(Color.Blue, 10), widthField - xGate, yGate - _heightGate, widthField, yGate - _heightGate);
            e.Graphics.DrawLine(new Pen(Color.Blue, 2), widthField-xGate, yGate, widthField-xGate, yGate - _heightGate);


            foreach (var item in game.BallsA)
            {
                e.Graphics.FillEllipse(Brushes.Blue, item.x, item.y, item.Width, item.Height);
                e.Graphics.DrawEllipse(Pens.Black, item.x, item.y, item.Width, item.Height);
            }

            foreach (var item in game.BallsB)
            {
                e.Graphics.FillEllipse(Brushes.Red, item.x, item.y, item.Width, item.Height);
                e.Graphics.DrawEllipse(Pens.Black, item.x, item.y, item.Width, item.Height);
            }

        }
        private void MoveBall_Tick(object sender, EventArgs e)
        {
            game.UpdateBalls();
            CountGoalA += game.KollGoal(game.BallsA);
            CountGoalB += game.KollGoal(game.BallsB);

            label1.Text = $"Счет Синии: {CountGoalA}";
            label2.Text = $"Счет Красные: {CountGoalB}"; 
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tmrMoveBall.Enabled = !this.tmrMoveBall.Enabled;
        }
    }
}
