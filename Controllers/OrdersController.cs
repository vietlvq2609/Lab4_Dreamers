using Lab4_Dreamers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Lab4_Dreamers.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var db = new OrdersContext();
            return View(db.GetOrdersFromDatabase());
        }
    }
}