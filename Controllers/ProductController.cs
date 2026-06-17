using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ModelViews;


namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductdbContext context;
        private readonly IWebHostEnvironment env;

        public ProductController(ProductdbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public async Task<IActionResult> Cart()
        {
            List<Product> prod = await context.Products.ToListAsync();
            return View(prod);

        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductImg prod)
        {
            if (ModelState.IsValid)
            {
                if (prod.imageName != null)
                {
                    string fn = Guid.NewGuid().ToString() + "_" + prod.imageName.FileName;
                    string folder = Path.Combine(env.WebRootPath, "ProdImages");
                    string imagepath = Path.Combine(folder, fn);
                    await prod.imageName.CopyToAsync(new FileStream(imagepath, FileMode.Create));

                    Product ur = new Product()
                    {
                        name = prod.name,
                        discription = prod.discription,
                        price = prod.price,
                        imageName = fn
                    };
                    await context.Products.AddAsync(ur);
                    context.SaveChanges();
                    TempData["Message"] = "Product Add successfully!";
                    return RedirectToAction("Cart");
                }
                else
                {
                    TempData["message"] = "Please select an photo!";
                    return RedirectToAction("Cart");
                }
            }
            return View(prod);
        }

   
    }

}
