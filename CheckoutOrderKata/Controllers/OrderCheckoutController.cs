using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutOrderKata.Models;
using CheckoutOrderKata.CheckoutLogic;
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
                ItemClassifier.CheckIfWeightedItem(item);
                resultMessage = itemScanner.AddItems(item);
            }
            catch(System.NullReferenceException)
            {
                resultMessage = "NullReferenceError; Make sure item scanned has the correct properties";
            }
            catch(System.ArgumentException exception)
            {
                resultMessage = exception.Message;
            }
            return Content(resultMessage);    
        }

        [HttpPost("RemoveOrderItem")]
        public ActionResult RemoveOrderItem(OrderItem item)
        {
            string resultMessage;
            try
            {
                ItemClassifier.CheckIfWeightedItem(item);
                resultMessage = itemScanner.RemoveItems(item);
            }
            catch (System.NullReferenceException)
            {
                resultMessage = "NullReferenceError; Make sure item scanned has the correct properties";
            }
            catch (System.ArgumentException exception)
            {
                resultMessage = exception.Message;
            }
            return Content(resultMessage);
        }
        [HttpGet("GetCheckoutTotal")]
        public ActionResult GetCheckoutTotal()
        {
            string resultMessage;
            try
            {
                resultMessage = $"Item total is ${itemScanner.GetCheckoutTotal()}";
            }
            catch (System.NullReferenceException exception)
            {
                resultMessage = "NullReferenceError; Make sure item scanned has the correct properties";
                Console.WriteLine(exception.Message);
            }
            return Content(resultMessage);
        }

    }
}
