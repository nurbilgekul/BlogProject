using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.EntityTypeConfiguration.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfiguration.Concrete
{
    public class CommentMap:BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Text).IsRequired(true);

            //composit key
            builder.HasKey(x => new { x.AppUserId, x.ArticleId });

            //builder.HasOne(x => x.Article)
            //    .WithMany(x => x.Comments)
            //    .HasForeignKey(x => x.AppUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne(x => x.AppUser)
            //    .WithMany(x => x.Comments)
            //    .HasForeignKey(x => x.AppUserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
