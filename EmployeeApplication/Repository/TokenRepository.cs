using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Repository
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(Context context) : base(context)
        {

        }

        public Context TokenContext
        {
            get { return dbContext as Context; }
        }
    }
}