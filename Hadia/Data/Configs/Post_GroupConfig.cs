using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_GroupMasterConfig : IEntityTypeConfiguration<Post_GroupMaster>
    {
        public void Configure(EntityTypeBuilder<Post_GroupMaster> builder)
        {
            builder.Property(x => x.GroupName).HasMaxLength(100);
            builder.Property(x => x.PassoutYear).HasMaxLength(125);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedGroups)
                .HasForeignKey(x => x.CLogin);

        }
    }
}
