using EmployeeApplication.Models;
using EmployeeMvc.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace EmployeeMvc.Controllers
{
    [CustomActionFilter]
    [HandleError]
    public class EmployeeMvcController : Controller
    {
        static HttpClient client1 = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:53297/"),
        };
        public static string authenticToken { get; set; }
            
        

        // GET: EmployeeMvc
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {

                HttpResponseMessage response = client1.PostAsJsonAsync("api/employee/AddEmployee", employee).Result;
                bool xyz = response.IsSuccessStatusCode;
                if (xyz == true)
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception exe)
            {
                return RedirectToAction("CreateEmployee");

               // return View();
            }
            // return View();
            return RedirectToAction("CreateEmployee");
        }
        public ActionResult Sucess()
        {
            return View();
        }


        public ActionResult GetEmployees()
        {



            HttpResponseMessage responseMessage = client1.GetAsync("http://localhost:53297/api/employee/").Result;


            if (responseMessage.IsSuccessStatusCode == true)
            {
                List<Employee> employeeList = responseMessage.Content.ReadAsAsync<List<Employee>>().Result;

                return View(employeeList);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }






        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            try
            {
                HttpResponseMessage response = client1.PostAsJsonAsync("api/employee/login", employee).Result;
                bool xyz = response.IsSuccessStatusCode;
                if (xyz == true)
                {
                    var user = employee.EmployeeUserName;
                    var password = employee.EmployeePassword;


                    string tokenValue = response.Content.ReadAsAsync<String>().Result;
                 //   string tokenValue1 = response.Content.ReadAsStringAsync().Result;



                  //  string[] withoutEscapeCharacterTokenValueArray = tokenValue1.Split('\"');
                    //string actualTokenValue = withoutEscapeCharacterTokenValueArray[1];


                    // var combinedValue = user + ":" + tokenValue;
                      var combinedValue = $"{user}:{tokenValue}";
                  //  var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{user}:{tokenValue}"));

                    client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", combinedValue);
                   // authenticToken = combinedValue;
                    Session["Token"] = combinedValue;
                    return RedirectToAction("GetEmployees");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception exe)
            {
                return View();
            }


        }






        public ActionResult DeleteEmployee(int id)
        {
            try
            {

                HttpResponseMessage response = client1.DeleteAsync("api/employee/" + id).Result;
                bool xyz = response.IsSuccessStatusCode;
                if (xyz == true)
                {
                    return RedirectToAction("GetEmployees");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login");
              //  return View();
            }
          //  return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            client1.DefaultRequestHeaders.Authorization = null;
            authenticToken = " ";
            client1.DefaultRequestHeaders.Accept.Clear();
            Session["Token"] = null;
            //Session.Clear();
            return RedirectToAction("Login");
        }


     


        public ActionResult EmployeeDetails(int id)
        {


            Employee employee = null;
            try
            {


                HttpResponseMessage response = client1.GetAsync($"api/employee/employee/{id}").Result;
              if(  response.IsSuccessStatusCode)
                {

                    employee = response.Content.ReadAsAsync<Employee>().Result;
                    return View(employee);
                }
                else
                {
                    return RedirectToAction("Login");
                }


            }
            catch (Exception exe)
            {
                return RedirectToAction("Login");
            }
           

        }









        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            Employee employee = null;
            try
            {

                HttpResponseMessage response = client1.GetAsync($"api/employee/employee/{id}").Result;
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {



                    employee = response.Content.ReadAsAsync<Employee>().Result;
                    return View(employee);
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login");
               // return View();
            }
            
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {

            try
            {

                HttpResponseMessage response = client1.PutAsJsonAsync("api/employee/" + employee.EmployeeId, employee).Result;
                bool xyz = response.IsSuccessStatusCode;
                if(xyz)
                return RedirectToAction("GetEmployees");
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login");
             //   return View();
            }
            
        }



        //public ActionResult GetStudio(int id)
        //{


        //    Studio studio = null;
        //    try
        //    {

        //        HttpResponseMessage response = client1.GetAsync($"api/employeeapi/studio/{id}").Result;
        //        //response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            studio = response.Content.ReadAsAsync<Studio>().Result;
        //            return View(studio);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index");

        //        }

        //    }
        //    catch (Exception exe)
        //    {

        //    }
        //    return View();

        //}


    }
}