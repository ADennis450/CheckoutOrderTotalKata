using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;

namespace CheckoutOrderKata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet("GetProductsAvailable")]
        public ActionResult GetProductsAvailable()
        {
          ProductItemDetail productDetail = new ProductItemDetail(); 
          return Content(productDetail.GetProductItems());
        }

    }
}
