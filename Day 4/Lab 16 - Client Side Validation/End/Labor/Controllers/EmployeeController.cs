using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Facade;
using Infra;
using Core;

namespace Labor.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly SalesDbContext db;
        public EmployeeController(SalesDbContext database) { db = database; }

        public ActionResult Index()
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
            return View("Index", model);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            if (BtnSubmit != "Save Employee") return RedirectToAction("Index");
            if (!ModelState.IsValid) return Create(e);
            return save(e);
        }

        private ActionResult save(Employee e)
        {
            Employees emp = new Employees();
            emp.Save(e, db);
            return RedirectToAction("Index");
        }

        private ActionResult Create(Employee e)
        {
            CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
            vm.FirstName = e.FirstName;
            vm.FirstName = e.LastName;
            if (e.Salary > 0) vm.Salary = e.Salary.ToString();
            vm.Salary = ModelState["Salary"].AttemptedValue;
            return View("CreateEmployee", vm);
        }
    }
}