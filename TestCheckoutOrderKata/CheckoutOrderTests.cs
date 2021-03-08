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
    public class CheckoutOrderTests
    {
       private ItemScanner scanner = new ItemScanner();
       List<OrderItem> orderItemList = new List<OrderItem>();
       
        [TestMethod]
        public void AddItem_ShouldAddItemToList()
        {
            string soupJson = "{'Name': 'soup','Units': 1, 'Special': 'None'}";
            
            OrderItem orderItem = JsonConvert.DeserializeObject<OrderItem>(soupJson);
            orderItemList = scanner.AddItems(orderItem);
            Assert.IsTrue(orderItemList.Count > 0);
        }
        [TestMethod]
        public void AddItem_ShouldReturnCorrectPricesPerUnit()
        {           
            OrderItem soupItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup','Units': 1, 'Special': 'None'}");
            OrderItem soupItem2 = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'soup','Units': 1, 'Special': 'None'}");
            OrderItem bananaItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'banana','Units': 2, 'Special': 'None'}");
            OrderItem groundBeefItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'groundbeef','Units': 3, 'Special': 'None'}");
            scanner.AddItems(soupItem);
            scanner.AddItems(soupItem2);
            scanner.AddItems(bananaItem);
            scanner.AddItems(groundBeefItem);
            Assert.AreEqual(3.78M, soupItem.Price);
            Assert.AreEqual(4.76M, bananaItem.Price);
            Assert.AreEqual(17.97M, groundBeefItem.Price);
        }
    }
}
