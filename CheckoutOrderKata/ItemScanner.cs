using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata
{
    public class ItemScanner
    {
        public ItemScanner()
        {
            OrderItemsList = new List<OrderItem>();
        }
        private decimal checkoutTotal { get; set; }
        public List<OrderItem> OrderItemsList;

        public string AddItems(OrderItem item)
        {

            if (OrderItemsList.Exists(x => x.Name == item.Name))
            {
                OrderItemsList.Find(x => x.Name == item.Name).Units += 1;
            }
            else
            {
                OrderItemsList.Add(item);
            }
            return AddItemMessage(item);
        }

        private string AddItemMessage(OrderItem item)
        {
            string checkoutTotal = GetCheckoutTotal();
            string itemMessage = (
            $"Order item was successfully scanned \n"
            + $"Checkout Total: {checkoutTotal}\n"
            );
            return itemMessage;
        }

        public void RemoveItems(OrderItem item)
        {
            if (OrderItemsList.Exists(x => x.Name == item.Name))
            {
                OrderItem removalItem = OrderItemsList.Find(x => x.Name == item.Name);
                removalItem.Units -= 1;
                if(removalItem.Units == 0)
                {
                    OrderItemsList.Remove(removalItem);
                }
            }
            else
            {
                throw new SystemException($"{item.Name} has not been scanned");
            }
        }
       
        public string GetCheckoutTotal()
        {
            foreach (OrderItem item in OrderItemsList)
            {
                checkoutTotal += item.TotalPrice;
            }
            return checkoutTotal.ToString();
        }
    }

}
