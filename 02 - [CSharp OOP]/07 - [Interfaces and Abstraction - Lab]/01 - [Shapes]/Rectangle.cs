using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private const char RECTANGLE_SYMBOL = '*';
        private const char RECTANGLE_WHITESPACE = ' ';

        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine(RECTANGLE_SYMBOL, RECTANGLE_SYMBOL);

            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(RECTANGLE_SYMBOL, RECTANGLE_WHITESPACE);
            }

            DrawLine(RECTANGLE_SYMBOL, RECTANGLE_SYMBOL);
        }

        private void DrawLine(char endSymbol, char middleSymbol)
        {
            DrawEndSymbol(endSymbol);

            for (int i = 1; i < this.width - 1; ++i)
            {
                Console.Write(middleSymbol);
            }

            DrawEndSymbol(endSymbol); 
            Console.WriteLine();
        }

        private static void DrawEndSymbol(char endSymbol)
                => Console.Write(endSymbol);
    }
}
