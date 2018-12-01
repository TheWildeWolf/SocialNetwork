using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class ResourcesConfig : IEntityTypeConfiguration<Resources>
    {
        public void Configure(EntityTypeBuilder<Resources> builder)
        {
            builder.HasOne(X => X.Member)
                  .WithMany(X => X.Resourceses)
                  .HasForeignKey(X => X.MemberId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(X => X.DeletedBy)
                .WithMany(X => X.ResourcesesDeleted)
                .HasForeignKey(x => x.DLogin)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
