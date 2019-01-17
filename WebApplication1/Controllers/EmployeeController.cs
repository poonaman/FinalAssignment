using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeWebApi.Models;
namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Employee
        public ActionResult Index()
        {

            db.EmployeesTable.ToList();
            db.StudiosTable.ToList();
            return View();
        }
    }
}