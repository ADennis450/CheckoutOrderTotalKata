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

       List<OrderItem> orderItemList = new List<OrderItem>();
       
        [TestMethod]
        public void AddItem_ShouldAddItemToList()
        {
            ItemScanner scanner = new ItemScanner();
            string chipJson = "{'Name': 'chips'}";
            OrderItem orderItem = JsonConvert.DeserializeObject<OrderItem>(chipJson);
            orderItemList = scanner.AddItems(orderItem);
            Assert.IsTrue(orderItemList.Count > 0);
            Assert.AreEqual(3.59M, orderItem.TotalPrice);
        }
        [TestMethod]
        public void AddItem_ItemPriceShouldBeDouble()
        {
            ItemScanner scanner = new ItemScanner();
            OrderItem chipItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            OrderItem chipItem2 = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            scanner.AddItems(chipItem);
            scanner.AddItems(chipItem2);
      
            Assert.AreEqual(7.18M, chipItem.TotalPrice);
        }
        [TestMethod]
        public void AddItem_ItemPriceShouldBePerPound()
        {
            ItemScanner scanner = new ItemScanner();
            OrderItem bananaItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'banana',  Pounds: 2}");
            scanner.AddItems(bananaItem);
            Assert.AreEqual(4.76M, bananaItem.TotalPrice);
        }
        [TestMethod]
        public void MarkdownPrice_ItemPriceShouldBeMarkedDown()
        {
            PriceCalculator calc = new PriceCalculator();
            SoupItem soupItem = new SoupItem();
            calc.MarkdownPrice(soupItem, true);
            Assert.AreEqual(1.59M, soupItem.Price);
        }
        [TestMethod]
        public void CalculatePriceWithDiscounts_AdditionalItemShouldBeAddedAtDiscount()
        {
            PriceCalculator calc = new PriceCalculator();
            GroundBeefItem groundBeefItem = new GroundBeefItem();
            decimal totalPrice = calc.CalculatePriceWithDiscounts(groundBeefItem, 12);
            Assert.AreEqual(59.9M, totalPrice);
        }
        [TestMethod]
        public void CalculatePriceWithDiscounts_ShouldCalculateCorrectDiscountPrice()
        {
            PriceCalculator calc = new PriceCalculator();
            BeerItem beerItem = new BeerItem();
            decimal Total = calc.CalculatePriceWithDiscounts(beerItem, 5);
            Assert.AreEqual(27.99M, Total);
        }
        [TestMethod]
        public void RemoveItem_ShouldRemoveItemFromList()
        {
            ItemScanner scanner = new ItemScanner();
            OrderItem chipItem = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            OrderItem chipItem2 = JsonConvert.DeserializeObject<OrderItem>("{'Name': 'chips'}");
            scanner.AddItems(chipItem);
            scanner.AddItems(chipItem2);
            orderItemList = scanner.RemoveItems(chipItem);

            Assert.IsTrue(orderItemList.Count == 1);
        }
    }
}
