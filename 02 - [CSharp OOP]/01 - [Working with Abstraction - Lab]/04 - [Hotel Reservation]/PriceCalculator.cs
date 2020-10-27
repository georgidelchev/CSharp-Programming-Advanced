using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public class PriceCalculator
    {
        public PriceCalculator(
            decimal pricePerDay,
            int daysCount,
            Season season,
            DiscountType discountType = 0)
        {
            this.PricePerDay = pricePerDay;
            this.DaysCount = daysCount;
            this.Season = season;
            this.DiscoundType = discountType;
        }

        public decimal PricePerDay { get; set; }

        public int DaysCount { get; set; }

        public Season Season { get; set; }

        public DiscountType DiscoundType { get; set; }

        public decimal PriceCalculation()
        {
            var price = this.PricePerDay *
                 this.DaysCount *
                 (int)this.Season;

            return price -= (int)this.DiscoundType * price / 100;
        }
    }
}
