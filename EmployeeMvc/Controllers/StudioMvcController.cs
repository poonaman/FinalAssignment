using EmployeeApplication.Models;
using EmployeeMvc.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMvc.Controllers
{
    [CustomActionFilter]
    public class StudioMvcController : Controller
    {
        static HttpClient client1 = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:53297/"),
        };

        public StudioMvcController()
        {
           // var combinedValue = (string)Session["Token"];
           // client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", combinedValue);

        }
       
        

        // GET: EmployeeMvc
       

        [HttpGet]
        
        public ActionResult CreateStudio()
        {
            string combinedValue = (string)Session["Token"];
            if(!string.IsNullOrEmpty(combinedValue))
                return View();
            else
                return RedirectToAction("Login", "EmployeeMvc");

            //    client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", combinedValue);


        }

        [HttpPost]
        public ActionResult CreateStudio(Studio studio)
        {
            try
            {

                HttpResponseMessage response = client1.PostAsJsonAsync("api/studio/", studio).Result;
                bool xyz = response.IsSuccessStatusCode;
                if (xyz == true)
                {
                    return RedirectToAction("GetStudios");
                }
            }
            catch (Exception exe)
            {
                return View();
            }
            return View();
        }
        public ActionResult Sucess()
        {
            return View();
        }


        public ActionResult GetStudios()
        {



            HttpResponseMessage responseMessage = client1.GetAsync("/api/studio/").Result;


            if (responseMessage.IsSuccessStatusCode == true)
            {
                List<Studio> studioList = responseMessage.Content.ReadAsAsync<List<Studio>>().Result;

                return View(studioList);
            }
            else
            {
                return RedirectToAction("Login","EmployeeMvc");
            }
        }









        public ActionResult DeleteStudio(int id)
        {
            try
            {

                HttpResponseMessage response = client1.DeleteAsync("api/studio/" + id).Result;
                bool xyz = response.IsSuccessStatusCode;
                if (xyz == true)
                {
                    return RedirectToAction("GetStudios");
                }
                else
                {
                    return RedirectToAction("Login", "EmployeeMvc");
                }
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login", "EmployeeMvc");
            //    return View();
            }
          //  return View();
        }
        public ActionResult Logout()
        {
            client1.DefaultRequestHeaders.Authorization = null;

            client1.DefaultRequestHeaders.Accept.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult StudioDetailsByName(string id)
        {
            var combinedValue = (string)Session["Token"];
            client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", combinedValue);

            Studio studio = null;
            try
            {


                HttpResponseMessage response = client1.GetAsync($"api/studio/studio/{id}").Result;

                if (response.IsSuccessStatusCode)
                {

                    studio = response.Content.ReadAsAsync<Studio>().Result;
                    return View(studio);
                }
                else
                {
                    return RedirectToAction("Login", "EmployeeMvc");
                }
               
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login", "EmployeeMvc");
            }
          

        }








        public ActionResult StudioDetails(int id)
        {


            Studio studio = null;
            try
            {


                HttpResponseMessage response = client1.GetAsync($"api/employee/studio/{id}").Result;
                response.EnsureSuccessStatusCode();
                studio = response.Content.ReadAsAsync<Studio>().Result;
                return View(studio);
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login", "EmployeeMvc");
            }
            return View();

        }

        [HttpGet]
        public ActionResult EditStudio(int id)
        {
            Studio studio = null;
            try
            {

                HttpResponseMessage response = client1.GetAsync($"api/employee/studio/{id}").Result;
                //response.EnsureSuccessStatusCode();
                //studio = response.Content.ReadAsAsync<Studio>().Result;
                //return View(studio);


                bool xyz = response.IsSuccessStatusCode;
                if (xyz)
                { 
                studio = response.Content.ReadAsAsync<Studio>().Result;
                return View(studio);
                }
                //return RedirectToAction("GetStudios");
                else
                    return RedirectToAction("Login", "EmployeeMvc");
            }
            catch (Exception exe)
            {
                return RedirectToAction("Login", "EmployeeMvc");
            }
            
        }

        [HttpPost]
        public ActionResult EditStudio(Studio studio)
        {

            try
            {

                HttpResponseMessage response = client1.PutAsJsonAsync("api/studio/" + studio.StudioId,studio).Result;
                bool xyz = response.IsSuccessStatusCode;
                if(xyz)
                return RedirectToAction("GetStudios");
                else
                return RedirectToAction("Login", "EmployeeMvc");

            }
            catch (Exception exe)
            {
                return RedirectToAction("Login", "EmployeeMvc");
            }
            
        }

    }
}