using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Repository
{
    public class StudioRepository : Repository<Studio>, IStudioRepository
    {
        public StudioRepository(Context context) : base(context)
        {

        }

        public Context EmployeeContext
        {
            get { return dbContext as Context; }
        }
    }
}