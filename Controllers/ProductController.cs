using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductdbContext context;

        public ProductController (ProductdbContext context)
        {
            this.context = context;
        }
        public IActionResult Cart()
        {
            List<Product> products = new List<Product>()
            {
               new Product { name = "boAt Airdopes 161/163", discription = "boAt Airdopes 161/163,ASAP Charge,40 H Battery, Stream Ad Free Music via App Support Bluetooth Headset (Pebble Black, True Wireless)", price = 999, imageName = "~/Images/img1.png.jpeg" },
               new Product { name = "boAt Airdopes 161/163", discription = "boAt Airdopes 161/163,ASAP Charge,40 H Battery, Stream Ad Free Music via App Support Bluetooth Headset (Pebble Black, True Wireless)", price = 999, imageName = "~/Images/img2.png.jpeg" },
               new Product { name = "boAt Airdopes 161/163", discription = "boAt Airdopes 161/163,ASAP Charge,40 H Battery, Stream Ad Free Music via App Support Bluetooth Headset (Pebble Black, True Wireless)", price = 999, imageName = "~/Images/img3.png.jpeg" }
            };
            return View(products);
        }
    }
}
