using Core;
using System.Collections.Generic;
using System.Linq;

namespace Infra
{
    public class Employees
    {
        public static List<Employee> Get(SalesDbContext db)
        {
            return db.Employees.ToList();
        }

        public Employee Save(Employee e, SalesDbContext db)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return e;
        }

        public static bool IsValidUser(UserDetails user)
        {
            if (user.UserName == "Admin" && user.Password == "Admin") return true;
            if (user.UserName == "Mari" && user.Password == "Mets") return true;
            return false;
        }

        public void UploadEmployees(List<Employee> employees, SalesDbContext db)
        {
            db.Employees.AddRange(employees);
            db.SaveChanges();
        }

    }
}
