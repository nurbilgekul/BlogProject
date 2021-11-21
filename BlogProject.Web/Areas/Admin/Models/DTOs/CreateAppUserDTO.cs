using BlogProject.Model.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CreateAppUserDTO
    {
        [Required (ErrorMessage ="Must to type into FirstName")]
        [MinLength(2, ErrorMessage ="Minimum Length is 2")]
        public string FirstName { get; set; }

        [Required (ErrorMessage ="Must to type into LastName")]
        [MinLength(2, ErrorMessage ="Minimum length is 2")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must to type into UserName")]
        [MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must to type into Password")]
        [MinLength(6, ErrorMessage = "Minimum length is 6")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }
    }
}
