using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Post_InterestedAreaConfig : IEntityTypeConfiguration<Post_InterestedArea>
    {
        public void Configure(EntityTypeBuilder<Post_InterestedArea> builder)
        {
            builder.HasOne(x => x.GroupMaster)
                  .WithMany(x => x.InterestedAreas)
                  .HasForeignKey(x => x.GroupId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.InterestedAreaMaster)
                .WithMany(x => x.InterestedAreas)
                .HasForeignKey(x => x.InterestedAreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
               .WithMany(x => x.CreatedinterestAreas)
               .HasForeignKey(x => x.CLogin)
               .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
