using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EmployeeApplication.Models;
using EmployeeApplication.Repository;

namespace EmployeeApplication.Dao
{
    public class StudioDao
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Context());
        public bool AddStudio(Studio studio)
        {
            try
            {
                //if (db.Studio.Any(x => x.EmpStudio == employee.EmpStudio))
                //{
                //    unitOfWork.Employees.Add(employee);
                //   // db.SaveChanges();
                //    return true;

                //}
                //else
                //{
                //    return false;
                //}
                unitOfWork.Studios.Add(studio);
                unitOfWork.complete();
                return true;


            }
            catch (Exception e)
            {

                throw new Exception("There was a problem saving this record: " + e.Message);
            }

        }
        public IEnumerable<Studio> GetStudios()
        {
            return unitOfWork.Studios.GetAll();
        }


        public bool DeleteById(int id)
        {
            Studio studio = unitOfWork.Studios.Get(id);
            if (studio == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No id with that task={0}", id)),
                    ReasonPhrase = "Not Found"
                };
                throw new HttpResponseException(resp);

            }
            unitOfWork.Studios.Remove(studio);
            unitOfWork.complete();
            return true;
        }

        public Studio GetStudio(int id)
        {
            return unitOfWork.Studios.Get(id);

        }

        public Studio GetStudioByName(string id)
        {
            return unitOfWork.Studios.Find(s => s.StudioName == id).FirstOrDefault();

        }


        public bool UpdateStudio(int id, Studio studio)
        {
            Studio Studio = unitOfWork.Studios.Get(id);
            if (Studio == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No id with that task={0}", id)),
                    ReasonPhrase = "Not Found"
                };
                throw new HttpResponseException(resp);

            }
            unitOfWork.Studios.Get(id).StudioName = studio.StudioName;
            unitOfWork.Studios.Get(id).StudioInformation= studio.StudioInformation;
           
            
            unitOfWork.complete();
            return true;
        }

        
    }
}
