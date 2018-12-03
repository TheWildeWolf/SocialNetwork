using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Com_ExecutiveMemberConfig : IEntityTypeConfiguration<Com_ExecutiveMember>
    {
        public void Configure(EntityTypeBuilder<Com_ExecutiveMember> builder)
        {
            builder.HasOne(x => x.HadiaCommittee)
                .WithMany(x => x.ExecMembers)
                .HasForeignKey(x => x.CommitteeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.ExMember)
                .HasForeignKey(x => x.MemberId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.ExCreatedBy)
                .HasForeignKey(x => x.CLogin).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ExModifiedBy)
                .HasForeignKey(x => x.MLogin).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
