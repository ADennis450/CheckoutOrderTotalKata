using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata
{
    public class ItemClassifier
    {
        public static ProductItem GetItemType(string name)
        {
            switch (name.ToLower().Replace(" ", string.Empty))
            {
                case "chips":
                  ChipsItem chipItem = new ChipsItem();
                    return chipItem;
                case "cookie":
                    CookieItem cookieItem = new CookieItem();
                    return cookieItem;
                case "soup":
                    SoupItem soupItem = new SoupItem();
                    return soupItem;
                case "banana":
                    BananaItem bananaItem = new BananaItem();
                    return bananaItem;
                case "groundbeef":
                    GroundBeefItem groundbeefItem = new GroundBeefItem();
                    return groundbeefItem;
                case "beer":
                    BeerItem beerItem = new BeerItem();
                    return beerItem;
                default:
                    throw new SystemException($"Item {name} is not a scannable item");
            }
        }

        public static void CheckIfWeightedItem(string name)
        {
          ProductItem item = GetItemType(name);
          if(!item.PriceByWeight)
          {
            throw new SystemException($"Item {name} is not an item priced by weight");
          }
        }
    }
}
