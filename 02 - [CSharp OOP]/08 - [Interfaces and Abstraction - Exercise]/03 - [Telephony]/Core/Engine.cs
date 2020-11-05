using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        public void Proceed()
        {
            var phoneNumbersToCall = Reading();

            var websitesToVisit = Reading();

            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            PrintPhoneNumbers(phoneNumbersToCall, smartphone, stationaryPhone);
            PrintWebsiteURLs(websitesToVisit, smartphone);
        }
        private static void PrintPhoneNumbers(List<string> phoneNumbersToCall, Smartphone smartphone, StationaryPhone stationaryPhone)
        {
            foreach (var item in phoneNumbersToCall)
            {
                if (!item.All(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (item.Length == 7)
                {
                    stationaryPhone.Call(item);
                }
                else
                {
                    smartphone.Call(item);
                }
            }
        }

        private static void PrintWebsiteURLs(List<string> websitesToVisit, Smartphone smartphone)
        {
            foreach (var item in websitesToVisit)
            {
                if (item.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartphone.Browse(item);
            }
        }

        private static List<string> Reading()
                => Console
                   .ReadLine()
                   .Split()
                   .ToList();
    }
}
