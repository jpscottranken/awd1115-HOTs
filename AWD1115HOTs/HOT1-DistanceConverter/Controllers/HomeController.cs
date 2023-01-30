using HOT1_DistanceConverter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HOT1_DistanceConverter.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Inches = 0.0;
            ViewBag.Centimeters = 0.0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(DistanceConverterModel result)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Inches = result.DistanceInInches();
                ViewBag.Centimeters = result.DistanceInCentimeters();
            }
            else
            {
                ViewBag.Inches = 0;
                ViewBag.Centimeters = 0;
            }
            return View();
        }
    }
}