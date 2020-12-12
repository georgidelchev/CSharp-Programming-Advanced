using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private decimal totalPrice = 0m;

        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = type switch
            {
                "Bread" => new Bread(name, price),
                "Cake" => new Cake(name, price),
                _ => null
            };

            this.bakedFoods.Add(food);

            var outputMessage = string.Format(OutputMessages.FoodAdded, name, type);
            return outputMessage;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                "Tea" => new Tea(name, portion, brand),
                "Water" => new Water(name, portion, brand),
                _ => null
            };

            this.drinks.Add(drink);

            var outputMessage = string.Format(OutputMessages.DrinkAdded, name, brand);
            return outputMessage;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                "InsideTable" => new InsideTable(tableNumber, capacity),
                "OutsideTable" => new OutsideTable(tableNumber, capacity),
                _ => null
            };

            this.tables.Add(table);

            var outputMessage = string.Format(OutputMessages.TableAdded, tableNumber);
            return outputMessage;
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables
                .FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            table?.Reserve(numberOfPeople);

            var result = table == null ?
                $"No available table for {numberOfPeople} people" :
                $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";

            return result;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = this.bakedFoods
                .FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}"; ;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = this.drinks
                .FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables
                .FirstOrDefault(t => t.TableNumber == tableNumber);

            var sb = new StringBuilder();

            if (table != null)
            {
                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {table.GetBill():f2}");
                totalPrice += table.GetBill();

                table.Clear();
            }

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables
                .Where(t => t.IsReserved == false)
                .ToList();

            var sb = new StringBuilder();

            foreach (var freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalPrice:f2}lv";
        }
    }
}