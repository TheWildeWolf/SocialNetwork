using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Sett_LoginLogConfig : IEntityTypeConfiguration<Sett_LoginLog>
    {
        public void Configure(EntityTypeBuilder<Sett_LoginLog> builder)
        {
            builder.HasOne(x => x.Member)
                 .WithMany(x => x.LoginLogs)
                 .HasForeignKey(x => x.MemberId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
