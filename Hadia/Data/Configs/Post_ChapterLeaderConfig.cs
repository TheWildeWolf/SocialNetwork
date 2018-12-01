using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Post_ChapterLeaderConfig : IEntityTypeConfiguration<Post_ChapterLeader>
    {
        public void Configure(EntityTypeBuilder<Post_ChapterLeader> builder)
        {
            builder.HasOne(x => x.Group)
               .WithMany(x => x.ChapterLeaders)
               .HasForeignKey(x => x.GroupId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
              .WithMany(x => x.LeaderInChapters)
              .HasForeignKey(x => x.MemberId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
             .WithMany(x => x.CreatedChapterLeaders)
             .HasForeignKey(x => x.CLogin)
             .OnDelete(DeleteBehavior.Restrict);

        }

       
    }
}
