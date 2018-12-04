using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Res_MasterConfig : IEntityTypeConfiguration<Res_Master>
    {
        public void Configure(EntityTypeBuilder<Res_Master> builder)
        {
            builder.HasOne(X => X.Member)
                  .WithMany(X => X.PostedResources)
                  .HasForeignKey(X => X.MemberId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(X => X.DeletedBy)
                .WithMany(X => X.ResourcesDeleted)
                .HasForeignKey(x => x.DLogin)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
