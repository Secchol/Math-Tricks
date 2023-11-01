using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Looping___Math_Tricks
{
    internal class Figure
    {
        private int _x;
        public int X 
        { 
            get { return _x; } 
            set { _x = value; } 
        }

        private int _y { get; set; }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        private int _sum;
        public int Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }

        public Figure(int x, int y, int sum)
        {
            this.X = x;
            this.Y = y;
            this.Sum = sum;
        }

        public void MoveAndSum(Button[,] btnMatrix, int moveToX, int moveToY)
        {
            X = moveToX;
            Y = moveToY;
            string mathAction = btnMatrix[moveToX, moveToY].Text.ToString();
            int numberToActWith = int.Parse(new string(btnMatrix[moveToX, moveToY].Text.ToString()[1], 1));
            switch (mathAction[0])
            {
                case '+': Sum += numberToActWith;
                    break;
                case '-': Sum -= numberToActWith;
                    break;
                case '*': Sum *= numberToActWith;
                    break;
                case '/': Sum /= numberToActWith;
                    break;
            }
        }

    }
}
