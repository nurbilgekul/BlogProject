using BlogProject.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.EntityTypeConfiguration.Abstract
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).IsRequired(false);
            builder.Property(x => x.CreatedComputerName).IsRequired(false);
            builder.Property(x => x.CreatedIp).IsRequired(false);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false);
            builder.Property(x => x.ModifiedIp).IsRequired(false);
            builder.Property(x => x.RemovedDate).IsRequired(false);
            builder.Property(x => x.RemovedComputerName).IsRequired(false);
            builder.Property(x => x.RemovedIp).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(true);
            
           
        }
    }
}
