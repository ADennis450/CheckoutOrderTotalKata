using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;
using System.Text.RegularExpressions;

namespace CheckoutOrderKata.CheckoutLogic
{
    public class PriceCalculator
    {
        public decimal GetItemFinalPrice(string itemName, int units, double weight, bool sale)
        {
            ProductItem item = ItemClassifier.GetItemType(itemName);
            double quantity = GetItemQuantity(units, weight, itemName);
            MarkdownPrice(item, sale);
            decimal itemTotal = CalculatePriceWithDiscounts(item, quantity);
            return itemTotal;
        }

        public void MarkdownPrice(ProductItem item, bool sale)
        {
            if (sale)
            {
                item.Price -= item.Markdown;
            }
        }

        public double GetItemQuantity(int units, double pounds, string itemName)
        {
            double quantity = 0;
            if(pounds > 0 )
            {
               quantity = pounds;
            }
            else
            {
                quantity = Convert.ToDouble(units);
            }
            return quantity;
        }

        public decimal CalculatePriceWithDiscounts(ProductItem item, double quantity)
        {
            if (item.DealQuantity > 0)
            {
                decimal totalForDiscountItems = 0M;
                double quantityToDealRatio = quantity / item.DealQuantity;
                int totalLimitLeft = (item.DealQuantity * item.Limit);
                int remainingQuantity = Convert.ToInt32(Math.Floor(quantity));
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
                return item.Price * Convert.ToDecimal(quantity);
            }
        }
    }
}
