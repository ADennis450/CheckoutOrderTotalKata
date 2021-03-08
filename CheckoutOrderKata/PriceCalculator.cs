using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata
{
    public class PriceCalculator
    {
        Prices prices = new Prices();
        public decimal GetItemPrice(string itemName, int units)
        {
            decimal itemPrice;
            switch(itemName.ToLower().Replace(" ", string.Empty))
            {
                case "soup":
                   itemPrice = prices.SoupPrice;
                   break;
                case "banana":
                    itemPrice = prices.BananaPrice;
                    break;
                case "groundbeef":
                    itemPrice = prices.GroundBeefPrice;
                    break;
                default:
                    itemPrice = 0;
                    break;
            }
            decimal finalPrice = itemPrice * units;
            return finalPrice;
        }

    }
}
