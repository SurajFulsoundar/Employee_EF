using Employee_EF.Data;

namespace Employee_EF.Models
{
    public class Product_DAL
    {
        ApplicationDbContext db;
        public Product_DAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAllCategory()
        {
           // return db.categories.ToList();

            var result = (from c in db.categories
                          select c).ToList();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            /*var result = db.categories.Where(x=> x.Cid ==  id).FirstOrDefault();
            return result;*/

            var result = (from c in db.categories
                          where c.Cid == id
                          select c).SingleOrDefault();
            return result;
        }

        public int AddCategory(Category category)
        {
            int res = 0;
            db.categories.Add(category);
            res = db.SaveChanges();
            return res;          

        }

        public int UpdateCategory(Category category)
        {
            
            int res = 0;            
          //  var result = db.categories.Where(x=> x.Cid == category.Cid).FirstOrDefault();

            var result = (from c in db.categories
                          where c.Cid == category.Cid
                          select c).FirstOrDefault();

            if(result != null)
            {
                result.Category_Name = category.Category_Name;
                res = db.SaveChanges();
            }
            return res;
        }

        public int DeleteCategory(int id)
        {
            int res = 0;

            //var result  = db.categories.Where(x=> x.Cid == id).FirstOrDefault();

            var result = (from c in db.categories
                          where c.Cid == id
                          select c).FirstOrDefault();
            if(result != null)
            {
                db.categories.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            //return db.product.ToList();            

            var result = (from p in db.product
                          join c in db.categories on p.Cid equals c.Cid
                          select new Product
                          {
                              Id = p.Id,
                              Product_Name = p.Product_Name,
                              Price = p.Price,
                              Cid = c.Cid,
                              Category_Name = c.Category_Name,
                          });
            return result.ToList();
        }

        public Product GetProductById(int id)
        {
       /*     var result = db.product.Where(x=> x.Id == id).FirstOrDefault();
            return result;*/

            var result = (from p in db.product
                          where p.Id == id
                          select p).FirstOrDefault();
            return result;
        }

        public int AddProduct(Product product)
        {
            int res = 0;
            var result = db.product.Add(product);
            res = db.SaveChanges();
            return res;        

        }
        public int UpdateProduct(Product product)
        {
            int res = 0;

           // var result = db.product.Where(x=> x.Id == product.Id).SingleOrDefault();

            var result = (from p in db.product
                          where p.Id == product.Id
                          select p).FirstOrDefault();   

            if(result != null) 
            {
                result.Product_Name = product.Product_Name;
                result.Price = product.Price;
                result.Cid = product.Cid;
                result.Category_Name = product.Category_Name;
                res = db.SaveChanges();
            }
            return res;

        }

        public int DeleteProduct(int id)
        {
            int res = 0;

            var result = db.product.Where(x=> x.Id == id).FirstOrDefault();
            if(result != null)
            {
                db.product.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }
    }
}
