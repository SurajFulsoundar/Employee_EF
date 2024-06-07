using Employee_EF.Data;
using Employee_EF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_EF.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext db;
        Product_DAL pro_dal;

        public ProductController(ApplicationDbContext db)
        {
            this.db = db;
            this.pro_dal = new Product_DAL (db);
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(pro_dal.GetAllProducts()); 
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var result = pro_dal.GetProductById(id);
            return View(result);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                int result = pro_dal.AddProduct(product);

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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = pro_dal.GetProductById(id);
                return View(result);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = pro_dal.UpdateProduct(product);
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = pro_dal.GetProductById(id);
            return View(result);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = pro_dal.DeleteProduct(id);
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
    }
}
