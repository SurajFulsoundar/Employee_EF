using Employee_EF.Data;
using Employee_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_EF.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext db;
        Employee_DAL employee_dal;

        public DepartmentController(ApplicationDbContext db)
        {
            this.db = db;
            employee_dal = new Employee_DAL(db);
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(employee_dal.GetAllDepartments());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var result = employee_dal.GetDepartmentById(id);
            return View(result);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                int result = employee_dal.AddDepartment(department);
                if (result >= 1)
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = employee_dal.GetDepartmentById(id);
            return View(result);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            try
            {
                int result = employee_dal.UpdateDepartment(department);
                if (result >= 1)
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = employee_dal.GetDepartmentById(id);
            return View(result);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = employee_dal.DeleteDepartment(id);
                if (result >= 1)
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
    }
}
