using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.ModelViews;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserdbContext context;
        private readonly IWebHostEnvironment env;

        public UserController(UserdbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public async Task<IActionResult> User1()
        {
            List<User> user = await context.Users.ToListAsync();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(UserImg model)
        {
            if (ModelState.IsValid)
            {
                if(model.ImageUrl !=null)
                {
                    string fn = Guid.NewGuid().ToString() + "_" + model.ImageUrl.FileName;
                    string folder = Path.Combine(env.WebRootPath, "UserImages");
                    string imagepath = Path.Combine(folder, fn);
                    await model.ImageUrl.CopyToAsync(new FileStream(imagepath, FileMode.Create));

                    User ur = new User()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        ImageUrl = fn
                    };
                    await context.Users.AddAsync(ur);
                    context.SaveChanges();
                    TempData["Message"] = "User Add successfully!";
                    return RedirectToAction("User1");
                }
                else
                {
                    TempData["message"] = "Please select an photo!";
                    return RedirectToAction("User");
                }
            }
            return View(model);
        }
    }
}
