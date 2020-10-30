using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        public Bag(string item, long qty)
        {
            this.Item = item;
            this.Qty = qty;
        }

        public string Item { get; set; }

        public long Qty { get; set; }
    }
}
