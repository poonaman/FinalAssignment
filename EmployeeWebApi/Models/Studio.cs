using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EmployeeWebApi.Models
{
    [Table("StudioTable")]
    public class Studio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioId { set; get; }

        public string StudioName { set; get; }

        public string StudioInformation { set; get; }

    }
}