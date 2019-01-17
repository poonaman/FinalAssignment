using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeWebApi.Models
{
    [Table("EmployeeTable")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { set; get; }

        public int EmployeeName { set; get; }

        public int EmployeeSalary { set; get; }

        public int EmployeeAge { set; get; }

        public int EmployeeStudio{ set; get; }

        public Studio Studio { set; get; }
     
    }
}