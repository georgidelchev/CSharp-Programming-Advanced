using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Player
    {
        public Player(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Symbol => 'S';
    }
}
