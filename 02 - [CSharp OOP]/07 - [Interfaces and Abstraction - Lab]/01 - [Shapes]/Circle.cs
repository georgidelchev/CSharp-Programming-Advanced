using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private const char CIRCLE_SYMBOL = '*';
        private const char CIRCLE_WHITESPACE = ' ';

        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double radiusIn = this.radius - 0.4;
            double radiusOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < radiusOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= radiusIn * radiusIn &&
                        value <= radiusOut * radiusOut)
                    {
                        Console.Write(CIRCLE_SYMBOL);
                    }
                    else
                    {
                        Console.Write(CIRCLE_WHITESPACE);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
