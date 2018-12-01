using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Res_ViewsConfig : IEntityTypeConfiguration<Res_Views>
    {
        public void Configure(EntityTypeBuilder<Res_Views> builder)
        {
            builder.HasOne(x => x.Resourceses)
                .WithMany(x => x.ResourceViews)
                .HasForeignKey(x => x.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.ResourcesViews)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
