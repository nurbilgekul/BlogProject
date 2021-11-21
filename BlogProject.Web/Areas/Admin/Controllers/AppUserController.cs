using AutoMapper;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepository;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserRepository appUserRepository, IMapper mapper)
        {
            this._appUserRepository = appUserRepository;
            this._mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var appuser = _mapper.Map<AppUser>(model);
                if (appuser.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save($"wwwroot/images/{appuser.UserName}.jpg");
                    appuser.Image = ($"/images/{appuser.UserName}.jpg");
                    _appUserRepository.Create(appuser);
                    return RedirectToAction("List");
                }
                else
                {
                    return View(model);
                }
               
            }
            else
            {
                return View(model);
            }
           
        }

        public IActionResult List()
        {
            var appUserList = _appUserRepository.GetByDefaults(
                selector: x => new GetAppUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password,
                    Role = x.Role,
                    Image = x.Image
                },
                expression: x => x.Status != Status.Passive);
            return View(appUserList);
        }

        public IActionResult Details(int id)
        {
            var appUserDetail = _appUserRepository.GetByDefault(
                selector: x => new GetDetailAppUserVM
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Image = x.Image,
                    Role = x.Role
                },
                expression: x => x.Status != Status.Passive);
            return View(appUserDetail);
        }
    }
}
