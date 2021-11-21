using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=> x.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=> x.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=> x.UserName).HasMaxLength(30).IsRequired(true);
            builder.Property(x=> x.Password).HasMaxLength(30).IsRequired(true);
            builder.Property(x=> x.Role).IsRequired(true);
            builder.Property(x=> x.Image).HasMaxLength(300).IsRequired(true);

            //builder.HasMany(x => x.Articles)
            //    .WithOne(x => x.AppUser)
            //    .HasForeignKey(x => x.AppUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(x => x.Comments)
            //    .WithOne(x => x.AppUser)
            //    .HasForeignKey(x => x.AppUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(x => x.Likes)
            //   .WithOne(x => x.AppUser)
            //   .HasForeignKey(x => x.AppUserId)
            //   .OnDelete(DeleteBehavior.Restrict);


            base.Configure(builder);
        }
        
        
       
    }
}
