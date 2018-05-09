using Core;
using Infra;
using Labor.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace Labor.Controllers
{
    public class BulkUploadController : Controller
    {
        private readonly SalesDbContext db;
        public BulkUploadController(SalesDbContext database)
        {
            db = database;
        }

        [AdminFilter]
        public IActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        public ActionResult Upload(IFormFile fileUpload)
        {
            List<Employee> employees = GetEmployees(fileUpload);
            Employees e = new Employees();
            e.UploadEmployees(employees, db);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(IFormFile file)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(file.OpenReadStream());
            csvreader.ReadLine();
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                employees.Add(e);
            }
            return employees;
        }
    }
}