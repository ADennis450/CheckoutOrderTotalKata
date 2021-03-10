using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;
using System.Text.RegularExpressions;

namespace CheckoutOrderKata
{
    public class PriceCalculator
    {

        public decimal GetItemFinalPrice(string itemName, int units, double pounds, bool sale)
        {
            decimal itemTotal = 0M;
            int wholelbs = Convert.ToInt32(pounds);

            switch(itemName.ToLower().Replace(" ", string.Empty))
            {
                case "chips":
                    ChipsItem chipsItem = new ChipsItem();
                    itemTotal = CalculateItemPrice(units, sale, chipsItem);
                    break;
                case "cookie":
                    CookieItem cookieItem = new CookieItem();
                    itemTotal = CalculateItemPrice(units, sale, cookieItem);
                    break;
                case "soup":
                    SoupItem soupItem = new SoupItem();
                    itemTotal = CalculateItemPrice(units, sale, soupItem);
                    break;
                case "banana":
                    BananaItem bananaItem = new BananaItem();
                    itemTotal = CalculateItemPrice(units, sale, bananaItem, pounds);
                    break;
                case "groundbeef":
                    GroundBeefItem groundbeefItem = new GroundBeefItem();
                    itemTotal = CalculateItemPrice(units, sale, groundbeefItem, pounds);
                    break;
                case "beer":
                    BeerItem beerItem = new BeerItem();
                    itemTotal = CalculateItemPrice(units, sale, beerItem, pounds);
                    break;
                default:
                    itemTotal = 0;
                    break;
            }
            return itemTotal;
        }

        public decimal CalculateItemPrice(int units, bool sale, ProductItem item, double pounds = 0)
        {
            decimal itemTotal= 0M;
            MarkdownPrice(item, sale);
            int quantity = GetItemQuantity(units, pounds);
            itemTotal = CalculatePriceWithDiscounts(item, quantity);
            return itemTotal;
        }

        public void MarkdownPrice(ProductItem item, bool sale)
        {
            if (sale)
            {
                item.Price -= item.Markdown;
            }
        }

        public int GetItemQuantity(int units, double pounds)
        {
            int quantity = 0;
            if(pounds > 0 )
            {
                quantity = Convert.ToInt32(pounds);
            }
            else
            {
                quantity = units;
            }
            return quantity;
        }
        //TODO: Refactor duplicate code in calculate item discount
        public decimal CalculatePriceWithDiscounts(ProductItem item, int quantity)
        {
            if (item.DealQuantity > 0)
            {
                decimal totalForDiscountItems = 0M;
                double quantityToDealRatio = quantity / item.DealQuantity;
                int totalLimitLeft = (item.DealQuantity * item.Limit);
                int remainingQuantity = quantity;
                int timesDealIsMet = Convert.ToInt32(Math.Floor(quantityToDealRatio));
                if (item.AdditionalItemDiscountPercent > 0)
                {
                    while (timesDealIsMet > 0 && totalLimitLeft > 0)
                    {
                        totalForDiscountItems += item.Price - (item.Price * item.AdditionalItemDiscountPercent);
                        remainingQuantity -= 1;
                        totalLimitLeft -= item.DealQuantity;
                        timesDealIsMet -= 1;
                    }
                }
                if (item.LowerPriceDiscount > 0)
                {
                    while (timesDealIsMet > 0 && totalLimitLeft > 0)
                    {
                        totalForDiscountItems += item.LowerPriceDiscount;
                        remainingQuantity -= item.DealQuantity;
                        totalLimitLeft -= item.DealQuantity;
                        timesDealIsMet -= 1;
                    }
                }
                decimal totalForNomalPricedItems = item.Price * remainingQuantity;
                decimal itemTotal = Decimal.Round(totalForNomalPricedItems + totalForDiscountItems, 2);
                return itemTotal;
            }
            else
            {
                return item.Price * quantity;
            }
        }
    }
}
