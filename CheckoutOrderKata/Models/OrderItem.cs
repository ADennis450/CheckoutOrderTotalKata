using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Units { get; set; } = 1;
        public bool Sale { get; set; } = false;
        public double Weight { get; set; } = 0;
        public decimal TotalPrice 
        { 
            get 
            {
                PriceCalculator calulator = new PriceCalculator();
                return calulator.GetItemFinalPrice(Name, Units, Weight, Sale);
            }
        }
        

    }
}
