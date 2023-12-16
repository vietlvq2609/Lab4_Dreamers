using Lab4_Dreamers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Dreamers.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: SuppliersController
        public ActionResult Index()
        {
            var db = new DbContext();
            return View(db.GetSuppliersFromDatabase());
        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            var db = new DbContext();
            var supplier = db.GetSuppliersFromDatabase().Find(s => s.SupplierID == id);
            return View();
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            
            var db = new DbContext();
            var supplier = db.GetSuppliersFromDatabase().Find(s => s.SupplierID == 1);
            return View(supplier);
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //create the supplier
                var db = new DbContext();
                var supplier = new Supplier()
                {
                    CompanyName = collection["CompanyName"],
                    ContactName = collection["ContactName"],
                    SupplierName = collection["SupplierName"],
                    Address = collection["Address"],
                    City = collection["City"],
                    Country = collection["Country"]
                };
                db.AddSupplier(supplier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new DbContext();
            var supplier = db.GetSuppliersFromDatabase().Find(s => s.SupplierID == id);
            return View(supplier);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var db = new DbContext();
                var supplier = new Supplier()
                {
                    CompanyName = collection["CompanyName"],
                    ContactName = collection["ContactName"],
                    SupplierName = collection["SupplierName"],
                    Address = collection["Address"],
                    City = collection["City"],
                    Country = collection["Country"]
                };
                db.UpdateSupplier(supplier);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new DbContext();
            var supplier = db.GetSuppliersFromDatabase().Find(s => s.SupplierID == id);
            return View(supplier);
        }

        // POST: SuppliersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var db = new DbContext();
                db.DeleteSupplier(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index(int choice = 0)
        {
            var db = new DbContext();
            var suppliers = db.GetSuppliers(choice);
            return View(suppliers);
        }
    }
}
