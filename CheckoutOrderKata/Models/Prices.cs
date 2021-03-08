using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutOrderKata.Models
{
    public class Prices
    {
        private readonly decimal soupPrice = 1.89M;
        private readonly decimal bananaPrice = 2.38M;
        private readonly decimal groudBeefPrice = 5.99M;

        public decimal SoupPrice { get { return soupPrice; } }
        public decimal BananaPrice { get { return bananaPrice; } }
        public decimal GroundBeefPrice { get { return groudBeefPrice; } }

    }
}
