using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using EmployeeApplication.Security;
namespace EmployeeApplication.Security
{
    public class JwtAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {


            if (actionContext.Request.Headers.Authorization.Parameter == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authorizatonToken = actionContext.Request.Headers.Authorization.Parameter;
                //  string decodedAuthorizationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authorizatonToken)); // in byte[] array form so we need 'Encoding.UTF8.GetString' to convert it  
                string[] decodedTokenarray = authorizatonToken.Split(':');
                string usrname = decodedTokenarray[0];
                //string pwd = decodedTokenarray[1];
                string tokenValue = decodedTokenarray[1];

                string tokenUserName = TokenManager.ValidateToken(tokenValue); // we will get the username

                if (usrname.Equals(tokenUserName))
                {
                    
                    //   actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Accepted);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }


            }








        }

    }
}