using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Interfaces.IBaseRepository;
using BlogProject.Infrastructure.Utilities;
using BlogProject.Model.Entities.Abstract;
using BlogProject.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace BlogProject.Infrastructure.Repositories.Abstract
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            this._table = _context.Set<T>();
        }
        public void Create(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreatedComputerName = Environment.MachineName;
            entity.CreatedIp = RemoteIPAddress.IPAdress;
            entity.Status = Status.Active;
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.RemovedDate = DateTime.Now;
            entity.RemovedComputerName = Environment.MachineName;
            entity.RemovedIp = RemoteIPAddress.IPAdress;
            entity.Status = Status.Passive;
            _context.Entry<T>(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }


        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedComputerName = Environment.MachineName;
            entity.ModifiedIp = RemoteIPAddress.IPAdress;
            entity.Status = Status.Modified;
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                    Expression<Func<T, bool>> expression,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table;
            if (expression != null) query = query.Where(expression);
            if (include != null) query = include(query);
            return query.Select(selector).ToList();
        }

        public TResult GetByDefault<TResult>(Expression<Func<T, bool>> expression,
                                             Expression<Func<T, TResult>> selector)
        {
            IQueryable<T> query = _table;
            if (expression != null) query = query.Where(expression);
            return query.Select(selector).FirstOrDefault();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.FirstOrDefault(expression);
        }

        public List<TResult> GetDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                    Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = _table;
            if (expression != null) query = query.Where(expression);
            return query.Select(selector).ToList();
        }
    }
}

