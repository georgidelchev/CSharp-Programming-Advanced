using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public int CalculateDaysDifferenceBetweenTwoDates(string firstDate, string secondDate)
        {
            var firstDateArgs = firstDate.Split().Select(int.Parse).ToList();
            var secondDateArgs = secondDate.Split().Select(int.Parse).ToList();

            DateTime firstDateTime = new DateTime(firstDateArgs[0], firstDateArgs[1], firstDateArgs[2]);
            DateTime secondDateTim = new DateTime(secondDateArgs[0], secondDateArgs[1], secondDateArgs[2]);
            
            return Math.Abs((int)firstDateTime.Subtract(secondDateTim).TotalDays);
        }
    }
}
