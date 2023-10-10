using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaMinhPhuoc_QLSV.Data;
using TaMinhPhuoc_QLSV.Models;

namespace TaMinhPhuoc_QLSV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            UserLoginModels loginModels = new UserLoginModels();
            return View(loginModels);
        }
        [HttpPost]
        public IActionResult Index(UserLoginModels loginModels)
        {
            QuanlysinhvienContext context = new QuanlysinhvienContext();
            var status = context.Users.Where(x => x.Username == loginModels.Username && x.Password == loginModels.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("Index", "Students");
            }
            return View(loginModels);
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