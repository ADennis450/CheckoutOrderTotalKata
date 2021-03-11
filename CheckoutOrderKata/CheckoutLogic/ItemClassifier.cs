using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata.CheckoutLogic
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
                    ProductItemDetail productDetail = new ProductItemDetail();
                    throw new ArgumentException(
                        $"Item {name} is not a scannable item. Please choose from the following items:\n"
                        + productDetail.GetProductItems());
            }
        }

        public static void CheckIfWeightedItem(OrderItem item)
        {
            ProductItem product = GetItemType(item.Name);
            if (!product.PriceByWeight && item.Weight > 0)
            {
                throw new ArgumentException($"Item {item.Name} is not an item priced by weight");
            }
            else if(product.PriceByWeight && item.Weight < 1)
            {
                throw new ArgumentException($"Item {item.Name} has to have a weight greater than 0");
            }
        }
}
   
}
