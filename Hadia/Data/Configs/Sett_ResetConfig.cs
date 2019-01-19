using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Sett_ResetConfig :IEntityTypeConfiguration<Sett_Reset>
    {
        public void Configure(EntityTypeBuilder<Sett_Reset> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.Resets)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Key).HasMaxLength(125).IsRequired();

        }
    }
}
