using Microsoft.AspNetCore.Mvc;
using MyAzurTest.Data;
using MyAzurTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAzurTest.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDBContext myContext;
        public EmployeeController(ApplicationDBContext DB)
        {
            myContext = DB;
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeModel> Emp = myContext.Employee;
            return View(Emp);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            EmployeeModel Employ = new EmployeeModel();
            return View(Employ);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel Employ)
        {
            Employ.id = myContext.Employee.Max(x => x.id)+1;

            myContext.Employee.Add(Employ);
            myContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
