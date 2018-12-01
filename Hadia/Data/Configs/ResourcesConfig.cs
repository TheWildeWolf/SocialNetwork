using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class ResourcesConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasOne(X => X.Member)
                  .WithMany(X => X.Resources)
                  .HasForeignKey(X => X.MemberId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(X => X.DeletedBy)
                .WithMany(X => X.ResourcesDeleted)
                .HasForeignKey(x => x.DLogin)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
