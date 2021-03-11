using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutOrderKata;
using CheckoutOrderKata.Models;
using CheckoutOrderKata.CheckoutLogic;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System;
namespace TestCheckoutOrderKata
{
    [TestClass]
    public class PriceCalculatorTests
    {
        PriceCalculator calc = new PriceCalculator();

        [TestMethod]
        public void MarkdownPrice_ItemPriceShouldBeMarkedDown()
        {    
            SoupItem soupItem = new SoupItem();
            calc.MarkdownPrice(soupItem, true);
            Assert.AreEqual(1.59M, soupItem.Price);
        }
        [TestMethod]
        public void AddItem_ItemPriceShouldBePerPound()
        {
            BananaItem bananaItem = new BananaItem();
            decimal itemTotal = calc.CalculateItemPrice(bananaItem, "banana", true, 0, 3 );
            Assert.AreEqual(7.14M, itemTotal);
        }
        [TestMethod]
        public void CalculatePriceWithDiscounts_ItemShouldHaveCorrectDiscount()
        {
            GroundBeefItem groundBeefItem = new GroundBeefItem();
            decimal totalPrice = calc.CalculatePriceWithDiscounts(groundBeefItem, 12);
            Assert.AreEqual(59.9M, totalPrice);
        }
        [TestMethod]
        public void CalculatePriceWithDiscounts_ShouldAdjustPriceCorrectly()
        {
            BeerItem beerItem = new BeerItem();
            decimal Total = calc.CalculatePriceWithDiscounts(beerItem, 5);
            Assert.AreEqual(27.99M, Total);
        }
    }
}
