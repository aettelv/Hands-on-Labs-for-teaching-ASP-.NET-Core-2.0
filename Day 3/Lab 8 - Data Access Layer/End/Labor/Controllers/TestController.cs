using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Facade;
using Infra;

namespace Labor.Controllers
{
    public class TestController : Controller
    {
        private readonly SalesDbContext db;
        public TestController(SalesDbContext db) { this.db = db; }
        public ActionResult GetView()
        {
            var model = new EmployeeListViewModel();
            var employees = Employees.Get(db);
            var list = new List<EmployeeViewModel>();
            foreach (var e in employees)
            {
                var employee = new EmployeeViewModel(e);
                list.Add(employee);
            }
            model.Employees = list;
            model.UserName = "Admin";
            return View("MyView", model);
        }
    }
}