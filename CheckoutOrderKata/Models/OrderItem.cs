using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutOrderKata.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Units { get; set; } = 1;
        public double Pounds { get; set; } = 0;
        public bool Sale { get; set; } = false;
        public decimal TotalPrice 
        { 
            get 
            {
                PriceCalculator calulator = new PriceCalculator();
                return calulator.GetItemFinalPrice(Name, Units, Pounds, Sale);
            }
        }
        

    }
}
