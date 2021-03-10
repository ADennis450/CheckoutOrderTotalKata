using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CheckoutOrderKata.Models
{
    public class Specials
    {
        public GroundBeefSpecial GroundBeefSpecial = new GroundBeefSpecial();
        public SoupSpecial SoupSpecial = new SoupSpecial();
        public BananaSpecial BananaSpecial = new BananaSpecial();
    }

    public class GroundBeefSpecial
    { 
        public string DealName => "Buy 3 lbs get 20% off, limit 1";
        public int Limit => 2;
        public int DealQuantity => 3;
        public decimal AdditionalItemDiscountPercent => 0.20M;
    }

    public class SoupSpecial
    {
        public  string DealName => "Buy 2 get 1 half off, limit 2";
        public int Limit => 4;
        public int DealQuantity => 2;
        public decimal DiscountPercent => 0.50M;
    }
    public class BananaSpecial
    {
        public string DealName => "Buy 2 bananas get 1 free, limit 3";
        public int Limit => 6;
        public int DealQuantity => 2;
        public decimal DiscountPercent => 1M;
    }

}
