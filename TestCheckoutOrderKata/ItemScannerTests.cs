using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderKata;
using CheckoutOrderKata.Models;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System;

namespace TestCheckoutOrderKata
{
    [TestClass]
    public class ItemScannerTests
    {
        ItemScanner scanner = new ItemScanner();
               
        [TestMethod]
        public void AddItem_ShouldAddItemToList()
        {
            string chipJson = "{'Name': 'chips'}";
            OrderItem orderItem = JsonConvert.DeserializeObject<OrderItem>(chipJson);
            scanner.AddItems(orderItem);
            Assert.IsTrue(ShoppingCart.OrderItemList.Count > 0);
            Assert.AreEqual(3.59M, orderItem.TotalPrice);
        }
        [TestMethod]
        public void AddItem_ItemPriceShouldBeDouble()
        {
            OrderItem chipItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            scanner.AddItems(chipItem);
            scanner.AddItems(chipItem);
      
            Assert.AreEqual(7.18M, chipItem.TotalPrice);
        }

        [TestMethod]
        public void RemoveItem_ShouldRemoveItemFromList()
        {
            ShoppingCart.OrderItemList.Clear();
            OrderItem chipItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            OrderItem soupItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup'}");
            scanner.AddItems(chipItem);
            scanner.AddItems(soupItem);
            scanner.RemoveItems(soupItem);

            Assert.IsTrue(ShoppingCart.OrderItemList.Count == 1);
        }
        [TestMethod]
        public void RemoveItem_ShouldInvalidateSpecial()
        {
            ShoppingCart.OrderItemList.Clear();
            OrderItem soupItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup', 'Units': 3}");
            OrderItem soupItem2 = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup', 'Units': 2}");
            scanner.AddItems(soupItem);
            scanner.RemoveItems(soupItem2);
            decimal checkoutTotal = scanner.GetCheckoutTotal();
            Assert.AreEqual(1.89M, checkoutTotal);
        }
    }
}
