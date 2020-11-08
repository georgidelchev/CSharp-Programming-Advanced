using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.ExceptionsMessages
{
    public class ExceptionMessage
    {
        public  const string FUEL_LESS_OR_EQUAL_TO_ZERO = "Fuel must be a positive number";

        public const string FUEL_AMOUNT_IS_BIGGER_THAN_THE_TANK = "Cannot fit {0} fuel in the tank";
    
        public static void CheckFuelQuantity(double fuelQuantity,double amount,double tankCapacity)
        {
            double currentFuelQuantity = fuelQuantity + amount;

            var msg = "";
            if (amount <= 0)
            {
                msg = ExceptionMessage.FUEL_LESS_OR_EQUAL_TO_ZERO;
                throw new ArgumentException(msg);
            }
            else if (currentFuelQuantity > tankCapacity)
            {
                msg = string.Format(ExceptionMessage.FUEL_AMOUNT_IS_BIGGER_THAN_THE_TANK, amount);
                throw new ArgumentException(msg);
            }
        }
    }
}
