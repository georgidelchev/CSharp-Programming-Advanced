using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.ProductsModels.ComputersModels
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
                    => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals
                    => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance +
                this.Components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price
             => base.Price +
                this.Peripherals.Sum(p => p.Price) +
                this.Components.Sum(c => c.Price);

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                var msg = string.Format
                (ExceptionMessages.ExistingComponent,
                    component.GetType().Name,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(msg);
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any() ||
                this.Components.All(c => c.GetType().Name != componentType))
            {
                var msg = string.Format
                (ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(msg);
            }

            var component = this.Components
                .FirstOrDefault(c => c.GetType().Name == componentType);

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                var msg = string.Format
                (ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(msg);
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any() ||
                this.Peripherals.All(c => c.GetType().Name != peripheralType))
            {
                var msg = string.Format
                (ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id);

                throw new ArgumentException(msg);
            }

            var peripheral = this.Peripherals
                .FirstOrDefault(c => c.GetType().Name == peripheralType);


            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            var overall = 0.0;

            if (this.Peripherals.Count != 0)
            {
                overall = this.Peripherals.Average(p => p.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); " +
                              $"Average Overall Performance " +
                              $"({overall:f2}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine("  " + peripheral.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}