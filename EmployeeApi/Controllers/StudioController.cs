using EmployeeApplication.Dao;
using EmployeeApplication.Models;
using EmployeeApplication.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeApi.Controllers
{
    public class StudioController : ApiController
    {
        StudioDao dao = new StudioDao();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [JwtAuthentication]
        public IHttpActionResult AddStudio(Studio studio)
        {
            if (studio == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No data present in the header")),
                    ReasonPhrase = "Not Found Data in the Header"
                };
                throw new HttpResponseException(resp);

            }
            if (dao.AddStudio(studio))
            {

                log.Info("Studio Added Successfully");
                return Ok(studio);
            }
            else
            {

                log.Error("Studio Not Added Successfully");
                return NotFound();
            }
        }

        [HttpGet]
        //   [BasicAuthentication]
        [JwtAuthentication]
        public IHttpActionResult GetStudioList()
        {
            IEnumerable<Studio> studios = dao.GetStudios();
            if (studios != null)
            {
                log.Info("Studio Retrieved Successfully");
                return Ok(dao.GetStudios());
            }
            else
            {
                log.Error("Studio could not be found");
                return NotFound();
            }


        }

        [HttpDelete]
        [JwtAuthentication]
        public void DeleteStudio(int id)
        {
            if (dao.DeleteById(id))
                log.Info("Studio Deleted Successfully");
            else
                log.Info("Studio Not Deleted ");
        }


        [HttpGet]
        [Route("api/employee/studio/{id}")]
        [JwtAuthentication]
        public Studio GetStudio(int id)
        {
            Studio studio = dao.GetStudio(id);
            if (studio != null)
            {
                log.Info("Studio Retrieved Successfully");
                return studio;
            }
            else
            {
                log.Error("Studio Retrieved Not Successfully");
                return null;
            }
        }

        [HttpGet]
        [Route("api/studio/studio/{id}")] //?
        [JwtAuthentication]
        public Studio GetStudio(string id)
        {
            Studio studio = dao.GetStudioByName(id);
            if (studio != null)
            {
                log.Info("Studio Retrieved Successfully");
                return studio;
            }
            else
            {
                log.Error("Studio Retrieved Not Successfully");
                return null;
            }
        }



        [HttpPut]
        [JwtAuthentication]
        public void UpdateStudio(int id, Studio studio)
        {
            if (dao.UpdateStudio(id,studio))
            {
                log.Info("Studio Information Updated Successfully");

            }
            else
            {
                log.Error("Not Updated");
            }
        }


    }



}

