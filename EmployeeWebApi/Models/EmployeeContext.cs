using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeWebApi.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("name=EmployeeContextConnection")
        {

        }
        public DbSet<Employee> EmployeesTable { set; get; }
        public DbSet<Studio> StudiosTable { set; get; }
    }
}