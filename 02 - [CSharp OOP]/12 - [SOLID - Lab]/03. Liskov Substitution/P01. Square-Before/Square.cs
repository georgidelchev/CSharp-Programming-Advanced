using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Square_Before
{
    public class Square : Rectangle
    {
        public override double Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override double Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}
