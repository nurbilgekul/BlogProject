using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Abstract;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepository;
using BlogProject.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Infrastructure.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

    }
}
