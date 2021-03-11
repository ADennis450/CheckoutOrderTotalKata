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
            Assert.IsTrue(scanner.OrderItemsList.Count > 0);
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
            OrderItem chipItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            scanner.AddItems(chipItem);
            scanner.AddItems(chipItem);
            scanner.RemoveItems(chipItem);

            Assert.IsTrue(scanner.OrderItemsList.Count == 1);
        }
        [TestMethod]
        public void RemoveItem_ShouldInvalidateSpecial()
        {
            OrderItem soupItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup', 'Units': 8}");

            Assert.AreEqual(11.34M, soupItem.TotalPrice);
        }
    }
}
