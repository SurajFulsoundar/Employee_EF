using Employee_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_EF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>op): base(op) 
        {

        }

        public DbSet<Employee> emp { get; set;}
        public DbSet<Department> department { get; set;}
        public DbSet<Product> product { get; set;}
        public DbSet<Category> categories { get; set;}
    }
}
