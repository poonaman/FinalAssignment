using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class Context:DbContext
    {
        public Context() : base("name=EmployeeContextConnection")
        {

        }
        public DbSet<Employee> EmployeesTable { set; get; }
        public DbSet<Studio> StudiosTable { set; get; }
        public DbSet<Token> TokensTable { set; get; }
    }
}