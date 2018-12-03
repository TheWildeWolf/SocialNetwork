using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Haf_MasterConfig : IEntityTypeConfiguration<Haf_Master>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Haf_Master> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.HAFmember)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.HAFCreatedBy)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.HAFModifiedBy)
                .HasForeignKey(x => x.MLogin);
        }
    }
}
