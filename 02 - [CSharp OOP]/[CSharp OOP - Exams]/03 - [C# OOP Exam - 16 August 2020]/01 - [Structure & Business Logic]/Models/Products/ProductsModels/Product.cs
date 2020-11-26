using System;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.ProductsModels
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this._id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                this._id = value;
            }
        }

        public string Manufacturer
        {
            get => this._manufacturer;
            private set
            {
                //TODO check this shit
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                this._manufacturer = value;
            }
        }

        public string Model
        {
            get => this._model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);

                }

                this._model = value;
            }
        }

        public virtual decimal Price
        {
            get => this._price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this._price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this._overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }

                this._overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return
            $"Overall Performance: {this.OverallPerformance:f2}. " +
            $"Price: {this.Price:f2} - {this.GetType().Name}: " +
            $"{this.Manufacturer} {this.Model} " +
            $"(Id: {this.Id})";
        }
    }
}