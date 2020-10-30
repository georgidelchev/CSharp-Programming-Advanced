using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Enemy
    {
        public Enemy(int row, int col, char symbol, string direction)
        {
            this.Row = row;
            this.Col = col;
            this.Symbol = symbol;
            this.Direction = direction;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Symbol { get; set; }

        public string Direction { get; set; }

        public void Move()
        {
            if (this.Direction == "right")
            {
                this.Col++;
            }
            else
            {
                this.Col--;
            }
        }

        public void ReplaceSymbol()
        {
            if (this.Symbol == 'b')
            {
                this.Symbol = 'd';
                this.Direction = "left";
            }

            if (this.Symbol == 'd')
            {
                this.Symbol = 'b';
                this.Direction = "right";
            }
        }
    }
}
