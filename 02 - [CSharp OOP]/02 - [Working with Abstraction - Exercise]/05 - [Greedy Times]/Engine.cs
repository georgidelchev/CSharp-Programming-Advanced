using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        public void Proceed()
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] safe = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            long totalGoldCount = 0;
            long totalRocksCount = 0;
            long totalCash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long qty = long.Parse(safe[i + 1]);

                string item = string.Empty;
                item = CheckItemType(name, item);

                if (CheckItem(bagCapacity, bag, qty, item))
                {
                    continue;
                }

                bool haveToContinue = false;

                haveToContinue = CheckingItems(bag, qty, item, haveToContinue);

                if (haveToContinue)
                {
                    continue;
                }

                AddingQtyToCurrentItem(bag, name, qty, item);

                CalculatingItemsCount(ref totalGoldCount, ref totalRocksCount, ref totalCash, qty, item);
            }

            PrintItems(bag);
        }

        private static bool CheckingItems(Dictionary<string, Dictionary<string, long>> bag, long qty, string item, bool haveToContinue)
        {
            switch (item)
            {
                case "Gem":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (qty > bag["Gold"].Values.Sum())
                            {
                                haveToContinue = HaveToContinue();
                            }
                        }
                        else
                        {
                            haveToContinue = HaveToContinue();
                        }
                    }
                    else if (bag[item].Values.Sum() + qty > bag["Gold"].Values.Sum())
                    {
                        haveToContinue = HaveToContinue();
                    }

                    break;
                case "Cash":
                    if (!bag.ContainsKey(item))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (qty > bag["Gem"].Values.Sum())
                            {
                                haveToContinue = HaveToContinue();
                            }
                        }
                        else
                        {
                            haveToContinue = HaveToContinue();
                        }
                    }
                    else if (bag[item].Values.Sum() + qty > bag["Gem"].Values.Sum())
                    {
                        haveToContinue = HaveToContinue();
                    }

                    break;
            }

            return haveToContinue;
        }

        private static bool HaveToContinue()
            => true;

        private static string CheckItemType(string name, string item)
        {
            if (name.Length == 3)
            {
                item = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                item = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                item = "Gold";
            }

            return item;
        }

        private static bool CheckItem(long bagCapacity, Dictionary<string, Dictionary<string, long>> bag, long qty, string item)
            => (item == "") ||
               (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + qty);

        private static void AddingQtyToCurrentItem(Dictionary<string, Dictionary<string, long>> bag, string name, long qty, string item)
        {
            if (!bag.ContainsKey(item))
            {
                bag[item] = new Dictionary<string, long>();
            }

            if (!bag[item].ContainsKey(name))
            {
                bag[item][name] = 0;
            }

            bag[item][name] += qty;
        }

        private static void CalculatingItemsCount(ref long totalGoldCount, ref long totalRocksCount, ref long totalCash, long qty, string item)
        {
            if (item == "Gold")
            {
                totalGoldCount += qty;
            }
            else if (item == "Gem")
            {
                totalRocksCount += qty;
            }
            else if (item == "Cash")
            {
                totalCash += qty;
            }
        }

        private static void PrintItems(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var mainItem in bag)
            {
                Console.WriteLine($"<{mainItem.Key}> ${mainItem.Value.Values.Sum()}");

                foreach (var item in mainItem
                    .Value
                    .OrderByDescending(y => y.Key)
                    .ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}
