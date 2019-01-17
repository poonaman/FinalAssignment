using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EmployeeApplication.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { set; get; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string EmployeeName { set; get; }

        [Required]
        [Range(1,100000)]
        public float EmployeeSalary { set; get; }

        [Required]
        [Range(1,50)]
        public int EmployeeAge { set; get; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string EmployeeStudio { set; get; }

        [Required]
        [StringLength(50,MinimumLength =4)]
        public string EmployeeUserName { set; get; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string EmployeePassword { set; get; }

        
        public Studio Studio { set; get; }

    }
}