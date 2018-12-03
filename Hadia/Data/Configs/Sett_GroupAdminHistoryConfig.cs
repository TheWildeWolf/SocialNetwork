using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Sett_GroupAdminHistoryConfig : IEntityTypeConfiguration<Sett_GroupAdminHistory>
    {
        public void Configure(EntityTypeBuilder<Sett_GroupAdminHistory> builder)
        {
            builder.HasOne(x => x.GroupMaster)
                  .WithMany(x => x.AdminGroup)
                  .HasForeignKey(x => x.GroupId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Member)
                 .WithMany(x => x.AdminHistory)
                 .HasForeignKey(x => x.MemberId)
                 .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
