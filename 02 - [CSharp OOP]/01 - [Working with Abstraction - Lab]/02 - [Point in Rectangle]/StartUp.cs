using System;
using System.Collections.Generic;
using System.Linq;

namespace PointInRectangle
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> coordinates = Reading();

            int firstCoordinate = coordinates[0];
            int secondCoordinate = coordinates[1];
            int thirdCoordinate = coordinates[2];
            int forthCoordinate = coordinates[3];

            var topLeftPoint = new Point(firstCoordinate, secondCoordinate);
            var bottomRightPoint = new Point(thirdCoordinate, forthCoordinate);

            var rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var pointCoordinate = Reading();

                var firstPointCoordinate = pointCoordinate[0];
                var secondPointCoordinate = pointCoordinate[1];

                Point currentPoint = new Point(firstPointCoordinate, secondPointCoordinate);
                
                Printing(rectangle, currentPoint);
            }
        }

        private static void Printing(Rectangle rectangle, Point currentPoint)
              => Console.WriteLine(rectangle.Contains(currentPoint));

        private static List<int> Reading()
              => Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
    }
}
