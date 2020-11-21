using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Contracts;
using CommandPattern.Enumerations;

namespace CommandPattern.Models
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this._product = product;
            this._priceAction = priceAction;
            this._amount = amount;
        }

        public void ExecuteAction()
        {
            if (this._priceAction == PriceAction.Increase)
            {
                this._product.IncreasePrice(this._amount);
            }
            else
            {
                this._product.DecreasePrice(this._amount);
            }
        }
    }
}
