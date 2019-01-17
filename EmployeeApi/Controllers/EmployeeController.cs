using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeApplication.Dao;
using EmployeeApplication.Models;
using EmployeeApplication.Security;

namespace EmployeeApi.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeDao dao = new EmployeeDao();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
  (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]

        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No data present in the header")),
                    ReasonPhrase = "Not Found Data in the Header"
                };
                throw new HttpResponseException(resp);

            }
            if (dao.AddEmployee(employee))
            {
                log.Info("Employee Added Successfully");
                return Ok(employee);
            }
            else
            {
                log.Error("Employe Not Added successfully");
                return NotFound();
            }
        }

        [HttpGet]
        [JwtAuthentication]
        public IHttpActionResult GetEmployees()
        {
            IEnumerable<Employee> employees=  dao.GetEmployees();
            if (employees != null)
            {
                log.Info("Employees Retrieved Successfully");
                return Ok(dao.GetEmployees());
            }
            else
            {
                log.Error("Employee could not be found");
                return NotFound();
            }
               
            


        }

        [HttpDelete]
        [JwtAuthentication]
        public void DeleteEmployees(int id)
        {
           if( dao.DeleteById(id))
            log.Info("Employee Deleted Successfully");
           else
                log.Info("Employee Not Deleted ");
        }


        [HttpGet]     
        [Route("api/employee/employee/{id}")]
        [JwtAuthentication]
        public Employee GetEmployee(int id)
        {
            
           Employee employee= dao.GetEmployee(id);
            if(employee!=null)
            {
                log.Info("Employee Retrieved Successfully");
                return employee;
            }
            else
            {
                log.Error("Employee Retrieved Not Successfully");
                return null;
            }
        }
        [HttpPut]
        [JwtAuthentication]
        public void UpdateEmployee(int id, Employee employee)
        {
            if (dao.UpdateEmployee(id, employee))
            {
                log.Info("Employee Information Updated Successfully");

            }
            else
            {
                log.Error("Not Updated");
            }
        }


      






        [HttpPost]
        [Route("api/employee/login")]
        public IHttpActionResult Check(Employee employee)
        {
            string tokenValue = EmployeeSecurity.Login(employee.EmployeeUserName, employee.EmployeePassword);
          
            if (tokenValue.Equals(" "))
            {
                log.Info("Employee  Not Logged in Successfully");
                return NotFound();
                
            }
            else
            {
                log.Info("Employee Logged in Successfully");
                return Ok(tokenValue);
            }


        }

    }
}
