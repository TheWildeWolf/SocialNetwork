using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Sett_DeviceInfoLogConfig : IEntityTypeConfiguration<Sett_DeviceInfoLog>
    {
        public void Configure(EntityTypeBuilder<Sett_DeviceInfoLog> builder)
        {
            builder.HasOne(x => x.Member)
                    .WithMany(x => x.DeviceInfoLogs)
                    .HasForeignKey(x => x.MemberId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Members)
                .WithOne(x => x.ActiveDevice)
                .HasForeignKey(x => x.ActiveDeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(x => x.DeviceModel).HasMaxLength(125);
            builder.Property(x => x.Brand).HasMaxLength(125);
        }
    }
}
