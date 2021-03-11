using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata.Models
{
    public static class ShoppingCart
    {
        static ShoppingCart()
        {
            OrderItemList = new List<OrderItem>();
        }
        public static List<OrderItem> OrderItemList { get; set; } 
    }
}
