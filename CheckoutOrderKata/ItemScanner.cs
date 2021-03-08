using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata
{
    public class ItemScanner
    {
        List<OrderItem> OrderItemsList = new List<OrderItem>();
        public List<OrderItem> AddItems(OrderItem item)
        {
            if (OrderItemsList.Exists(x => x.Name == item.Name))
            {
                OrderItemsList.Find(x => x.Name == item.Name).Units += item.Units;
            }
            else
            {
                OrderItemsList.Add(item);
            }
            return OrderItemsList;
        }
    }
}
