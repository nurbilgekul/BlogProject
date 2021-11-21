using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        [NotMapped] //sütun olarak ayağa kalkma görünme
        public IFormFile ImagePath { get; set; }

        public int CategoryId { get; set; }
        public List<GetCategoryVM> Categories{ get; set; }


        public int AppUserId { get; set; }
        public List<GetAppUserVM> AppUsers { get; set; }

    }
}
