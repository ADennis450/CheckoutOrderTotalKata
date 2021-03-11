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
        public OrderCheckoutController() 
        {
             itemScanner = new ItemScanner();
        }

        ItemScanner itemScanner;

        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        [HttpPost("CreateOrderItem")]
        public ActionResult CreateOrderItem(OrderItem item)
        {
            string resultMessage;
            try
            {
                resultMessage = itemScanner.AddItems(item);
            }
            catch(System.NullReferenceException exception)
            {
                resultMessage = "NullReferenceError; Make sure item scanned has the correct properties";
                Console.WriteLine(exception.Message);
            }
            return Content(resultMessage);    
        }
    }
}
