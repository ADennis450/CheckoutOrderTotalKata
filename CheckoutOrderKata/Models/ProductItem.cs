using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutOrderKata.Models
{
    public abstract class ProductItem
    {
        public abstract decimal Price { get; set; }
        public abstract decimal Markdown { get; }
        public abstract string DealName { get; }
        public abstract int Limit { get; }
        public abstract int DealQuantity { get;}
        public abstract decimal AdditionalItemDiscountPercent { get;}
        public abstract decimal LowerPriceDiscount { get; }
        public abstract bool PriceByWeight { get; }
    }

    public class ChipsItem : ProductItem
    {
        public override decimal Price { get; set; } = 3.59M;
        public override decimal Markdown => 0M;
        public override string DealName => "";
        public override int Limit => 0;
        public override int DealQuantity => 0;
        public override decimal AdditionalItemDiscountPercent => 0M;
        public override decimal LowerPriceDiscount => 0M;
        public override bool PriceByWeight => false;
    }

    public class CookieItem : ProductItem
    {
        public override decimal Price { get; set; } = 3.69M;
        public override decimal Markdown => 0.40M;
        public override string DealName => "";
        public override int Limit => 0;
        public override int DealQuantity => 0;
        public override decimal AdditionalItemDiscountPercent => 0M;
        public override decimal LowerPriceDiscount => 0M;
        public override bool PriceByWeight => false;
    }

    public class SoupItem : ProductItem
    {
       public override decimal Price { get; set; } = 1.89M;
       public override decimal Markdown => 0.30M;
        public override string DealName => "Buy 2 get 1 half off, limit 2";
        public override int Limit => 4;
        public override int DealQuantity => 2;
        public override decimal AdditionalItemDiscountPercent => 0.50M;
        public override decimal LowerPriceDiscount => 0M;
        public override bool PriceByWeight => false;
    }

    public class BananaItem : ProductItem
    {
        public override decimal Price { get; set; } = 2.38M;
        public override decimal Markdown => 0M;
        public override string DealName => "";
        public override int Limit => 0;
        public override int DealQuantity => 0;
        public override decimal AdditionalItemDiscountPercent => 0M;
        public override decimal LowerPriceDiscount => 0M;
        public override bool PriceByWeight => true;
    }

    public class GroundBeefItem : ProductItem
    {
        public override decimal Price { get; set; } = 5.99M;
        public override decimal Markdown => 0M;
        public override string DealName => "Buy 3 get 1 50% off, limit 2";
        public override int Limit => 6;
        public override int DealQuantity => 3;
        public override decimal AdditionalItemDiscountPercent => 0.50M;
        public override decimal LowerPriceDiscount => 0M;
        public override bool PriceByWeight => true;
    }

    public class BeerItem : ProductItem
    {
        public override decimal Price { get; set; } = 7.99M;
        public override decimal Markdown => 0M;
        public override string DealName => "Buy 2 For $10, limit 2";
        public override int Limit => 2;
        public override int DealQuantity => 2;
        public override decimal AdditionalItemDiscountPercent => 0M;
        public override decimal LowerPriceDiscount => 10M;
        public override bool PriceByWeight => false;
    }
}
