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
                OrderItemsList.Find(x => x.Name == item.Name).Units += 1;
            }
            else
            {
                OrderItemsList.Add(item);
            }
            return OrderItemsList;
        }
        public List<OrderItem> RemoveItems(OrderItem item)
        {
            if (OrderItemsList.Exists(x => x.Name == item.Name))
            {
                OrderItem removalItem = OrderItemsList.Find(x => x.Name == item.Name);
                removalItem.Units -= 1;
                if(removalItem.Units == 0)
                {
                    OrderItemsList.Remove(removalItem);
                }
                return OrderItemsList;
            }
            else
            {
                throw new SystemException($"{item.Name} has not been scanned");
            }
        }
    }
}
