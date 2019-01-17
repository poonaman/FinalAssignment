using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace EmployeeApplication.Security
{
    public class TokenManager
    {
        private static string secret = "XCAP05H6LoKvbRRa/QkqLNMI7cOHguaRyHzyg7n5qEkGjQmtBhz4SzYh4Fqwjyi3KJHlSXKPwVu2+bXr6CtpgQ==";
        //this is the secret key for the tokens

        public string GenerateToken(string name)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            //secrey key must be converted to a byte array to be used as SymmetricSecurityKey   
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);



            var claimsIdentity = new ClaimsIdentity(new List<Claim>()
           {
               new Claim(ClaimTypes.Name, name)

           }, "Custom");

            //this is a custom claim

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = signingCredentials,
                Subject = claimsIdentity
            };

            //HD- Handler,Descriptor

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken jwtSecurityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            string jwtSecurityTokenSigned = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return jwtSecurityTokenSigned;

        }


        public static string ValidateToken(string token)
        {
            string name = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            ClaimsIdentity identity;
            if (principal == null)
            {
                return null;
            }
            else
            {

                identity = (ClaimsIdentity)principal.Identity;
                Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
                string username = usernameClaim.Value;
                return username;

            }


        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            byte[] key = Convert.FromBase64String(secret);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);

            //TVP(MVP)
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = false,
                ValidateIssuer = false,
                ValidateAudience = false,

                IssuerSigningKey = symmetricSecurityKey
            };

            SecurityToken securityToken;
            JwtSecurityTokenHandler jwtSecurityTokenHandler1 = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = jwtSecurityTokenHandler1.ValidateToken(token, tokenValidationParameters, out securityToken);
            return principal;
        }
    }
}