using AutoMapper;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepository;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public ArticleController(IArticleRepository articleRepository,
                                ICategoryRepository categoryRepository,
                                IAppUserRepository appUserRepository,
                                IMapper mapper)
        {
            this._articleRepository = articleRepository;
            this._appUserRepository = appUserRepository;
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        public IActionResult Create()
        {
            CreateArticleDTO model = new CreateArticleDTO
            {
                Categories = _categoryRepository.GetDefaults(
                    selector: x => new GetCategoryVM
                    {
                        Id = x.Id,
                        Name = x.Name
                    },
                    expression: x => x.Status != Status.Passive),

                AppUsers = _appUserRepository.GetDefaults(
                    selector: x => new GetAppUserVM
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                    },
                    expression: x => x.Status != Status.Passive & x.Role == Role.Author)
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateArticleDTO model)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(model);
                if (article.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save($"wwwroot/images/{article.Image}.jpg");
                    article.Image = ($"/images/{article.Image}.jpg");
                    _articleRepository.Create(article);
                    return RedirectToAction("List");
                }
                else  return View(model);
            }
            else return View(model);
           
        }
         
        public IActionResult List()
        {
            var articleList = _articleRepository.GetByDefaults(
                selector: x => new GetArticleVM
                {
                    Title = x.Title,
                    Content = x.Content,
                    CategoryName = x.Category.Name,
                    AuthorName = x.AppUser.FullName,
                    Image = x.Image
                },
                expression: x=> x.Status!= Status.Passive,
                include: x=> x.Include(z=> z.Category).Include(z=> z.AppUser)
                );
            return View(articleList);
        }

    }
}
