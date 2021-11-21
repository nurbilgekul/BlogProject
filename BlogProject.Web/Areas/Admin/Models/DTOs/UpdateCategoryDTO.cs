using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must to type in name")]
        [MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type in description")]
        [MinLength(3, ErrorMessage = "Minimum Length is 3")]
        public string Description { get; set; }
        //public DateTime? CreateDate { get; set; }
        //public string CreatedComputerName { get; set; }
        //public string CreatedIp { get; set; }
    }
}
