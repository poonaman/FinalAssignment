using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeApplication.Models;

namespace EmployeeApplication.Repository
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        {

        }

        public Context EmployeeContext
        {
            get { return dbContext as Context; }
        }


    }
}