using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Formats.Cbor;
using WebApp.Models;
using WebApp.ModelViews;

namespace WebApp.Controllers
{   
    public class HomeController : Controller
    { 
        private readonly ILogger<HomeController> _logger;
        private readonly MultiModelContext context;
        public HomeController(ILogger<HomeController> logger , MultiModelContext context )
        {
            _logger = logger;
             this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(int? Id)
        {
            if (Id!=null)
            {
                CourseWiseStudent crs = new CourseWiseStudent();
                crs.crsDetails = context.Courses.FirstOrDefault(item => item.CourseId == Id);
                if(crs.crsDetails!=null)
                {
                    crs.studDetails = context.Students.Where(item => item.CourseId == Id).ToList();
                    return View(crs);
                }
                else
                {
                    TempData["error"] = "Please Enter a Valid Course Id";
                    return RedirectToAction("Index");
                }

            }

            TempData["error"] = "Please enter a course id";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
