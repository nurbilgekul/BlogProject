using BlogProject.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogProject.Infrastructure.Repositories.Interfaces.IBaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetDefault(Expression<Func<T, bool>> expression);

        List<TResult> GetDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                           Expression<Func<T, bool>> expression);


        TResult GetByDefault<TResult>(Expression<Func<T, bool>> expression,
                                      Expression<Func<T, TResult>> selector);


        List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                             Expression<Func<T, bool>> expression,
                                             Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
