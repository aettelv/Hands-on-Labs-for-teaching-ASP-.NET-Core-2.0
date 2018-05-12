using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Facade;
using Infra;
using Core;
using Microsoft.AspNetCore.Authorization;
using System;
using Labor.Filters;

namespace Labor.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly SalesDbContext db;
        public EmployeeController(SalesDbContext database) { db = database; }

        [Authorize]
        public ActionResult Index()
        {
            var model = new EmployeeListViewModel();
            model.UserName = User.Identity.Name;
            var employees = Employees.Get(db);
            var list = new List<EmployeeViewModel>();
            foreach (var e in employees)
            {
                var employee = new EmployeeViewModel(e);
                list.Add(employee);
            }
            model.Employees = list;
            model.FooterData = new FooterViewModel();
            model.FooterData.CompanyName = "TTÜ";
            model.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", model);
        }
        [Authorize]
        [AdminFilter]
        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }
        [AdminFilter]
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