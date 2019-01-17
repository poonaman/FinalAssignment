using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApplication.Repository;
using EmployeeApplication.Models;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using EmployeeApplication.Security;

namespace EmployeeApplication.Dao
{
    public class EmployeeDao
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Context());

        public bool AddEmployee(Employee employee)
        {
            try
            {
                //if (unitOfWork.Studios.(x => x.StudioName == employee.EmployeeStudio).FirstOrDefault())
                //{
                //    db.Employees.Add(employee);
                //    db.SaveChanges();
                //    return true;

                //}

                IEnumerable<Studio> studioList = unitOfWork.Studios.GetAll();
                if (studioList.Any(s => s.StudioName == employee.EmployeeStudio))
                {
                    unitOfWork.Employees.Add(employee);
                    unitOfWork.complete();


                    string tokenvalue = new TokenManager().GenerateToken(employee.EmployeeUserName); // step 1 - generate token on registration
                    Token token = new Token()
                    {
                        UserName = employee.EmployeeUserName,
                        Password = employee.EmployeePassword,
                        TokenValue = tokenvalue

                    };
                    unitOfWork.Tokens.Add(token);// why is this line in employeedao and tokendao? // step 2 - token username and pwd added in database
                    unitOfWork.complete();

                    return true;

                }
                else
                {
                    return false;
                }

               
             

                
            }
            catch (Exception e)
            {

                throw new Exception("There was a problem saving this record: " + e.Message);
            }

        }
        public IEnumerable<Employee> GetEmployees()
        {
            return unitOfWork.Employees.GetAll();
        }


        public bool DeleteById(int id)
        {
            Employee employee = unitOfWork.Employees.Get(id);
            if (employee == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No id with that task={0}", id)),
                    ReasonPhrase = "Not Found"
                };
                throw new HttpResponseException(resp);

            }
            unitOfWork.Employees.Remove(employee);
          unitOfWork.complete();
            return true;
        }

        public Employee GetEmployee(int id)
        {
            return unitOfWork.Employees.Get(id);

        }
        public bool UpdateEmployee(int id, Employee employee)
        {
            Employee employe = unitOfWork.Employees.Get(id);
            if (employe == null)
            {
                
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No id with that task={0}", id)),
                    ReasonPhrase = "Not Found"
                };
                throw new HttpResponseException(resp);
                return false;
            }
            unitOfWork.Employees.Get(id).EmployeeName = employee.EmployeeName;
            unitOfWork.Employees.Get(id).EmployeeAge = employee.EmployeeAge;
            unitOfWork.Employees.Get(id).EmployeeSalary = employee.EmployeeSalary;
            unitOfWork.Employees.Get(id).EmployeeStudio = employee.EmployeeStudio;
            // db.Employees.Where(x => x.EmpId == id).FirstOrDefault().EmpSalary = employee.EmpSalary;
            //db.Employees.Where(x => x.EmpId == id).FirstOrDefault().EmpStudio = employee.EmpStudio;
            unitOfWork.complete();
            return true;
        }

        //public Studio GetStudio(int id)
        //{
        //    Studio studio = db.Studios.Where(x => x.StudioId == id).FirstOrDefault();
        //    return studio;
        //}
    }
}