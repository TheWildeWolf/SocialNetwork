using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_CommentViewConfig : IEntityTypeConfiguration<Post_CommentView>
    {
        public void Configure(EntityTypeBuilder<Post_CommentView> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.ViewedComments)
                .HasForeignKey(x => x.MemberId);

            builder.HasOne(x => x.Comment)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.CommentId);
        }
    }
}
