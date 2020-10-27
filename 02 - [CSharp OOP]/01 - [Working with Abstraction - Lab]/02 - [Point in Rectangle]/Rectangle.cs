using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            this.TopLeftPoint = topLeftPoint;
            this.BottomRightPoint = bottomRightPoint;
        }

        public Point TopLeftPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public bool Contains(Point point)
        {
            var isXInside = point.X <= this.BottomRightPoint.X && point.X >= this.TopLeftPoint.X;
            var isYInside = point.Y <= this.BottomRightPoint.Y && point.Y >= this.TopLeftPoint.Y;
            return isXInside && isYInside;
        }
    }
}
