using BlogProject.Infrastructure.Utilities;
using BlogProject.Model.Entities.Abstract;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Concrete;
using BlogProject.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogProject.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());

            base.OnModelCreating(modelBuilder);
        }

        //public override int SaveChanges()
        //{
        //    var modifiedEntities = ChangeTracker.Entries()
        //                                        .Where(x => x.State == EntityState.Added ||
        //                                                    x.State == EntityState.Modified ||
        //                                                    x.State == EntityState.Deleted)
        //                                        .ToList();

        //    string computerName = Environment.MachineName;
        //    string ipAddress = RemoteIPAddress.IPAdress;

        //    DateTime date = DateTime.Now;

        //    foreach (var item in modifiedEntities)
        //    {
        //        BaseEntity entity = item.Entity as BaseEntity;

        //        if (item != null)
        //        {
        //            switch (item.State)
        //            {

        //                case EntityState.Deleted:
        //                    entity.RemovedComputerName = computerName;
        //                    entity.RemovedDate = date;
        //                    entity.RemovedIp = ipAddress;
        //                    entity.Status = Status.Passive;
        //                    break;
        //                case EntityState.Modified:
        //                    entity.ModifiedComputerName = computerName;
        //                    entity.ModifiedDate = date;
        //                    entity.ModifiedIp = ipAddress;
        //                    entity.Status = Status.Modified;
        //                    break;
        //                case EntityState.Added:
        //                    entity.CreatedComputerName = computerName;
        //                    entity.CreateDate = date;
        //                    entity.CreatedIp = ipAddress;
        //                    entity.Status = Status.Active;
        //                    break;
        //            }
        //        }
        //    }

        //    return base.SaveChanges();
        //}

    }
}
