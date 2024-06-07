using Employee_EF.Data;
using Employee_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_EF.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db;
        Product_DAL pro_dal;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
            pro_dal = new Product_DAL(db);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(pro_dal.GetAllCategory());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = pro_dal.GetCategoryById(id);
            return View(result);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = pro_dal.AddCategory(category);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = pro_dal.GetCategoryById(id);
            return View(result);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = pro_dal.UpdateCategory(category);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                       return View() ;
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = pro_dal.GetCategoryById(id);
            return View(result);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = pro_dal.DeleteCategory(id);
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
