using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
    public class EmployeeController : Controller
    {
        Context db = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            db.EmployeesTable.ToList();
            db.StudiosTable.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

    }
}