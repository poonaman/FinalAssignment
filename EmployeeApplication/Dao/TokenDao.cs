using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Dao
{
    public class TokenDao
    {
        UnitOfWork unitOfWork = new UnitOfWork(new Context());
        public bool AddToken(Token token)
        {
            try
            {
                
                unitOfWork.Tokens.Add(token);
                unitOfWork.complete();
                return true;


            }
            catch (Exception e)
            {

                throw new Exception("There was a problem saving this record: " + e.Message);
            }

        }

        public Token GetToken(string username)
        {
            return unitOfWork.Tokens.Find(e => e.UserName.Equals(username)).FirstOrDefault();

        }





    }
}