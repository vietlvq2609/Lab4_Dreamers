using Lab4_Dreamers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Dreamers.Controllers
{
    public class SuppliersController : Controller
    {
        public ActionResult Index(int choice = 0)
        {
            var db = new DbContext();
            var suppliers = db.GetSuppliers(choice);
            return View(suppliers);
        }
    }
}
