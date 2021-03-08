using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;
using Newtonsoft.Json;
using System.Web;

namespace CheckoutOrderKata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCheckoutController : ControllerBase
    {

        ItemScanner itemScanner = new ItemScanner();

        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateOrderItem(OrderItem item)
        {
             itemScanner.AddItems(item);
             return Content(JsonConvert.SerializeObject(item));
        }

    }
}
