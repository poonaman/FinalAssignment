using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EmployeeApplication.Models
{
    [Table("StudioTable")]
    public class Studio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioId { set; get; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string StudioName { set; get; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string StudioInformation { set; get; }
    }
}