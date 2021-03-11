using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata.CheckoutLogic
{
    public class ItemScanner
    {

        public string AddItems(OrderItem item)
        {

            if (ShoppingCart.OrderItemList.Exists(x => x.Name == item.Name))
            {
                ShoppingCart.OrderItemList.Find(x => x.Name == item.Name).Units += 1;
            }
            else
            {
                ShoppingCart.OrderItemList.Add(item);
            }
            string checkoutTotal = GetCheckoutTotal().ToString();
            return checkoutTotal;
        }

        public void RemoveItems(OrderItem item)
        {
            if ( ShoppingCart.OrderItemList.Exists(x => x.Name == item.Name))
            {
                OrderItem removalItem = ShoppingCart.OrderItemList.Find(x => x.Name == item.Name);
                removalItem.Units -= 1;
                if(removalItem.Units == 0)
                {
                    ShoppingCart.OrderItemList.Remove(removalItem);
                }
            }
            else
            {
                throw new SystemException($"{item.Name} has not been scanned");
            }
        }
       
        public decimal GetCheckoutTotal()
        {
            decimal checkoutTotal = 0M;
            foreach (OrderItem item in ShoppingCart.OrderItemList)
            {
                checkoutTotal += item.TotalPrice;
            }
            return checkoutTotal;
        }
    }

}
