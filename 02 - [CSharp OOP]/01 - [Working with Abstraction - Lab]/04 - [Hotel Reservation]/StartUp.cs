using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> input = Reading();

            var pricePerDay = decimal.Parse(input[0]);
            var totalDaysCount = int.Parse(input[1]);
            var season = Enum.Parse<Season>(input[2]);
            var discountType = Enum.Parse<DiscountType>("None");

            discountType = ValidateDiscountType(input, discountType);

            var priceCalculator = new PriceCalculator(pricePerDay, totalDaysCount, season, discountType);
            Console.WriteLine($"{priceCalculator.PriceCalculation():f2}");
        }

        private static DiscountType ValidateDiscountType(List<string> input, DiscountType discountType)
        {
            if (input.Count == 4)
            {
                discountType = Enum.Parse<DiscountType>(input[3]);
            }

            return discountType;
        }

        private static List<string> Reading()
               => Console
                .ReadLine()
                .Split()
                .ToList();
    }
}
