using AutoMapper;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Web.Models.Mapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryVM>().ReverseMap();
            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, GetAppUserVM>().ReverseMap();
            CreateMap<AppUser, GetDetailAppUserVM>().ReverseMap();
            CreateMap<Article, CreateArticleDTO>().ReverseMap();

        }
    }
}
