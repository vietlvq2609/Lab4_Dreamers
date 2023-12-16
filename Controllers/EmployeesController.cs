using Lab4_Dreamers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Dreamers.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            var db = new DbContext();
            return View(db.GetEmployeesFromDatabase()); 
        }

        //view all employees without orders
        public IActionResult EmployeeWithoutOrders()
        { 
            var db = new DbContext();
            var employees = db.GetEmployeesFromDatabase();
            var orders = new List<Order>();
            var employeesWithoutOrders = employees.FindAll(e => !orders.Exists(o => o.EmployeeID == e.EmployeeID));
            return View(employeesWithoutOrders);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            var db = new DbContext();
            var employee = db.GetEmployeesFromDatabase().Find(e => e.EmployeeID == id);
            return View(employee);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            var db = new DbContext();
            var employee = db.GetEmployeesFromDatabase().Find(e => e.EmployeeID == 1);
            return View(employee);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var db = new DbContext();
                var employee = new Employee()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    JobTitle = collection["JobTitle"],
                    PrimaryPhone = collection["PrimaryPhone"]
                };
                db.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new DbContext();
            var employee = db.GetEmployeesFromDatabase().Find(e => e.EmployeeID == id);
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var db = new DbContext();
                var employee = db.GetEmployeesFromDatabase().Find(e => e.EmployeeID == id);
                employee.FirstName = collection["FirstName"];
                employee.LastName = collection["LastName"];
                employee.JobTitle = collection["JobTitle"];
                employee.PrimaryPhone = collection["PrimaryPhone"];
                db.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var db = new DbContext();
                var employee = db.GetEmployeesFromDatabase().Find(e => e.EmployeeID == id);
                db.DeleteEmployee(employee.EmployeeID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
