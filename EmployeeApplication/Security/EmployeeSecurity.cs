using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using EmployeeApplication.Dao;
namespace EmployeeApplication.Security
{
    public class EmployeeSecurity
    {


        public static string Login(string username, string password)
        {
            TokenDao dao = new TokenDao();
            UnitOfWork unitOfWork = new UnitOfWork(new Context());
            Employee employee = unitOfWork.Employees.Find(e => e.EmployeeUserName.Equals(username) && e.EmployeePassword.Equals(password)).FirstOrDefault();
            if (employee != null) // means employee exits in the database
            {
                Token token = unitOfWork.Tokens.Find(t => t.UserName.Equals(username) && t.Password.Equals(password)).FirstOrDefault();
                string tokenUserName = TokenManager.ValidateToken(token.TokenValue);

                if (tokenUserName.Equals(username))
                    return token.TokenValue;
                else
                    return " ";
                // we find the entire token for the respective employee
            }
            else
            {
                return " ";
            }

        }


    }
}




        //on the basis of username now we need to check if any token in the database already has this username. so we do not need to generate a new token.
        //we retrieve the token from the database, generate a new token too.
        // for both of them we check for validity.

        //generate token = generates a token
        //validate token - here we pass a token as a string and we get the username as a response.

        // so when we log in the EmpManSystem, we have a username against which we have to check soemthing.
        // so now what to validate the token against?

    //    string tokenValue = new TokenManager().GenerateToken(username);

//          //  Token token = dao.GetToken(username);
//            if (token != null)
//            {
//                if ((token.TokenValue).Equals(tokenValue))
//                {

//                    return tokenValue;
//                }

//                else
//                {
//                    return " ";
//                }

//            }
//            else
//            {
           
//                    return " ";
//            }
            
           

//          // return " ";

//        }
//    }
//}