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
        { return user.UserName == "Admin" && user.Password == "Admin"; }
    }
}
