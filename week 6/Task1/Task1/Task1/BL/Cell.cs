using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.DL;
using Task1.UI;

namespace Task1.BL
{
    class Cell
    {
        
        public char value;
        public int X;
        public int Y;
        public Cell(char value, int X, int Y)
        {
            this.value = value;
            this.X = X;
            this.Y = Y;
        }

        public char getValue()
        {
            return value;
        }

        public void setValue(char newValue)
        {
            value = newValue;
        }

        public int getX()
        {
            return X;
        }

        public int getY()
        {
            return Y;
        }

        public bool IsPacmanPresent()
        {
            return value == 'P';
        }

        public bool IsGhostPresent()
        {
            return value == 'G';
        }
    }
}
