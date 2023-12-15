using Lab4_Dreamers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Lab4_Dreamers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var db = new DbContext();
            return View(db.GetSuppliersFromDatabase());
        }

        public IActionResult Details(Supplier sp)
        {
            return View(sp);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}