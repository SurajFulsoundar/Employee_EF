using Employee_EF.Data;

namespace Employee_EF.Models
{
    public class Employee_DAL
    {
        ApplicationDbContext db;

        public Employee_DAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
           // var result= db.department.ToList();

            var result = (from d in db.department
                          select d).ToList();
            return result;
        }
        public Department GetDepartmentById(int id)
        {
         /*   var result = db.department.Where(x => x.Id == id).FirstOrDefault();
            return result;*/

            var res = (from d in db.department
                      where d.Did == id
                      select d).FirstOrDefault();
            return res;
        }

        public int AddDepartment(Department department)
        {
            db.department.Add(department);
            int res = db.SaveChanges();
            return res;
        }

        public int UpdateDepartment(Department department)
        {
            int res = 0;

            var result = (from d in db.department
                          where d.Did == department.Did
                          select d).SingleOrDefault();

            if(result != null)
            {
                result.DName = department.DName;
                res = db.SaveChanges();
            }
            return res;
            
        }

        public int DeleteDepartment(int id)
        {
            int res = 0;
            var result = (from d in db.department
                       where d.Did == id
                       select d).SingleOrDefault();
            if (result != null)
            {
                db.department.Remove(result);
                res = db.SaveChanges();
                
            }
            return res;
         
        }


        public IEnumerable<Employee> GetAllEmployee()
        {        

            var result = (from e in db.emp
                          join d in db.department on e.Did equals d.Did
                          select new Employee
                          {
                              Id = e.Id,
                              Name = e.Name,
                              Email = e.Email,
                              Age = e.Age,
                              Salary = e.Salary,
                              Did = d.Did,
                              DName = d.DName
                          });

            return result.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
          //  var result = db.employees.Where(x=> x.Id == id).FirstOrDefault();
           // return result;

            var result = (from e in db.emp
                          join d in db.department on e.Did equals d.Did
                          where e.Id == id
                          select new Employee
                          {
                              Id = e.Id,
                              Name = e.Name,
                              Email = e.Email,
                              Age = e.Age,
                              Salary = e.Salary,
                              Did = d.Did,
                              DName = d.DName
                          });
            return result.FirstOrDefault();
        }

        public int AddEmployee(Employee employee)
        {
            int res = 0;
            db.emp.Add(employee);
            res = db.SaveChanges();
            return res;
            
        }
        public int UpdateEmployee(Employee employee)
        {
            //var result  = db.emp.Where(x=> x.Id == employee.Id).SingleOrDefault();

            int res = 0;

             var result = (from e in db.emp
                          where e.Id == employee.Id
                          select e).SingleOrDefault();

            if(result != null)
            {
                result.Name = employee.Name;
                result.Email = employee.Email;
                result.Age = employee.Age;
                result.Salary = employee.Salary;
                result.Did = employee.Did;
                res = db.SaveChanges();
            }
            return res;

        }

        public int DeleteEmployee(int id)
        {
           // var result = db.emp.Where(x=> x.Id == id).FirstOrDefault();

            int res = 0;
            var result = ( from e in db.emp
                           where e.Id == id
                           select e).SingleOrDefault();
            if(result != null)
            {
                db.emp.Remove(result);
                res = db.SaveChanges();
            }
            return res;
           
        }

    }
}
