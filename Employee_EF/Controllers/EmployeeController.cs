using Employee_EF.Data;
using Employee_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_EF.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db;
        Employee_DAL employee_dal;

        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
            employee_dal = new Employee_DAL(db);
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(employee_dal.GetAllEmployee());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = employee_dal.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int result = employee_dal.AddEmployee(employee);
                if(result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var emp  = employee_dal.GetEmployeeById(id);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int result = employee_dal.UpdateEmployee(employee);
                if(result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = employee_dal.GetEmployeeById(id);
            return View(result);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int res = employee_dal.DeleteEmployee(id);
                if(res >=  1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
;                }
            }
            catch
            {
                return View();
            }
        }
    }
}
