using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutOrderKata.Models
{
    public class OrderItem
    {
        public string Name { get; set; }
        public int Units { get; set; }
        public string Special { get; set; }
        public decimal Price 
        { 
            get 
            {
                PriceCalculator calulator = new PriceCalculator();
                return calulator.GetItemPrice(Name, Units);
            }
        }
        

    }
}
