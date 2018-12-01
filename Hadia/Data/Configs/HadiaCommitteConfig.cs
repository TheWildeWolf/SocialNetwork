using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Com_MasterConfig : IEntityTypeConfiguration<Com_Master>
    {
        public void Configure(EntityTypeBuilder<Com_Master> builder)
        {
            builder.HasOne(x => x.President)
                .WithMany(x => x.MemPresident)
                .HasForeignKey(x => x.PresidentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vice1)
                .WithMany(x => x.MemVice1)
                .HasForeignKey(x => x.Vice1Id).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Vice2)
                .WithMany(x => x.MemVice2)
                .HasForeignKey(x => x.Vice2Id).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Secretery)
                .WithMany(x => x.MemSecretery)
                .HasForeignKey(x => x.SecreteryId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JointSecr1)
                .WithMany(x => x.MemJointSecr1)
                .HasForeignKey(x => x.JointSecretery1Id).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.JointSecr2)
                .WithMany(x => x.MemJointSecr2)
                .HasForeignKey(x => x.JointSecretery2Id).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Treasurer)
                .WithMany(x => x.MemTreasurer)
                .HasForeignKey(x => x.TreasurerId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.MemCreatedBy)
                .HasForeignKey(x => x.CLogin).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Modified)
                .WithMany(x => x.MemModifiedBy)
                .HasForeignKey(x => x.MLogin).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
