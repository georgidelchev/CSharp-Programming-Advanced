using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.ProductsModels.ComponentsModels;
using OnlineShop.Models.Products.ProductsModels.ComputersModels;
using OnlineShop.Models.Products.ProductsModels.PeripheralsModels;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;

        public Controller()
        {
            this.computers = new List<IComputer>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.TryParse(computerType, out ComputerType currentComputerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            var computer = CreateComputer(id, manufacturer, model, price, currentComputerType);

            this.computers.Add(computer);

            var outputMessage = string.Format(SuccessMessages.AddedComputer, id);

            return outputMessage;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            if (!Enum.TryParse(peripheralType, out PeripheralType currentPeripheralType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            var peripheral = CreatePeripheral(id, manufacturer, model, price, overallPerformance, connectionType, currentPeripheralType);

            var computer = this.computers
                .FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            computer.AddPeripheral(peripheral);

            var outputMessage = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

            return outputMessage;
        }


        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = this.computers
                .FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var peripheral = computer.RemovePeripheral(peripheralType);

            var outputMessage = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);

            return outputMessage;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            if (!Enum.TryParse(componentType, out ComponentType currentComponentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            var component = CreateComponent(id, manufacturer, model, price, overallPerformance, generation, currentComponentType);

            var computer = this.computers
                .FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (computer.Components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            computer.AddComponent(component);

            var outputMessage = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

            return outputMessage;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = this.computers
                .FirstOrDefault(c => c.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var component = computer.RemoveComponent(componentType);

            var outputMessage = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

            return outputMessage;
        }

        public string BuyComputer(int id)
        {
            var computer = this.computers
                .FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                var msg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);

                throw new ArgumentException(msg);
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = this.computers
                .FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer.ToString();
        }

        private static IComputer CreateComputer(int id, string manufacturer, string model, decimal price, ComputerType currentComputerType)
        {
            IComputer computer = currentComputerType switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price),
            };

            return computer;
        }

        private static IPeripheral CreatePeripheral(int id, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType, PeripheralType currentPeripheralType)
        {
            IPeripheral peripheral = currentPeripheralType switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance,
                    connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType),
            };

            return peripheral;
        }

        private static IComponent CreateComponent(int id, string manufacturer, string model, decimal price, double overallPerformance,
            int generation, ComponentType currentComponentType)
        {
            IComponent component = currentComponentType switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price,
                    overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance,
                    generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance,
                    generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price,
                    overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance,
                    generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance,
                    generation),
            };

            return component;
        }
    }
}