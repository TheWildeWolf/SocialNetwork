using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Config
    {
        
    }

    public class Post_CommentConfig : IEntityTypeConfiguration<Post_Comment>
    {
        public void Configure(EntityTypeBuilder<Post_Comment> builder)
        {
            builder.HasOne(x => x.DeletedBy)
                .WithMany(x => x.DeletedComments)
                .HasForeignKey(x => x.RemovedId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x => x.Master)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
