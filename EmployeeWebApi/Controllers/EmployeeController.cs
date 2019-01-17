using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeContext db = new EmployeeContext();
        public List<Employee> GetEmployees()
        {
            return db.EmployeesTable.ToList();
        }
    }
}
