using HOT1_2_OrderForm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HOT1_2_OrderForm.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Quantity        = 0;
            ViewBag.DiscountCode    = "";
            ViewBag.DiscountMessage = "";
            ViewBag.PricePerShirt   = 0.0;
            ViewBag.Subtotal        = 0.0;
            ViewBag.Tax             = 0.0;
            ViewBag.Total           = 0.0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderForm result)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Quantity        = result.DisplayQuantity();
                ViewBag.DiscountCode    = result.DisplayDiscountCode();
                ViewBag.DiscountMessage = result.DisplayDiscountMessage();
                ViewBag.PricePerShirt   = result.DisplayPricePerShirt();
                ViewBag.Subtotal        = result.DisplaySubtotal();
                ViewBag.Tax             = result.DisplayTax();
                ViewBag.Total           = result.DisplayTotal();
            }
            else
            {
                ViewBag.Quantity = 0;
                ViewBag.DiscountCode = "";
                ViewBag.DiscountMessage = "";
                ViewBag.PricePerShirt = 0.0;
                ViewBag.Subtotal = 0.0;
                ViewBag.Tax = 0.0;
                ViewBag.Total = 0.0;
            }
            return View();
        }
    }
}