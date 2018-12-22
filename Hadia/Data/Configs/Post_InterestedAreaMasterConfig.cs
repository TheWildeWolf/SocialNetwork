using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Post_InterestedAreaMasterConfig : IEntityTypeConfiguration<Post_InterestedAreaMaster>
    {
        public void Configure(EntityTypeBuilder<Post_InterestedAreaMaster> builder)
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.InterestedAreaMasterCreated)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
