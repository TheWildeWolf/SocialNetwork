using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_GroupMembersConfig : IEntityTypeConfiguration<Post_GroupMember>
    {
        public void Configure(EntityTypeBuilder<Post_GroupMember> builder)
        {
            builder.HasOne(x => x.AddedMember)
                .WithMany(x => x.MembersAdded)
                .HasForeignKey(x => x.AddedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ModifiedMember)
                .WithMany(x => x.MembersModified)
                .HasForeignKey(x => x.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict); ;


            builder.HasOne(x => x.GroupMaster)
                .WithMany(x => x.GroupMembers)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
