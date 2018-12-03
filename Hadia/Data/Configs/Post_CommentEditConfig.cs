using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_CommentEditConfig : IEntityTypeConfiguration<Post_CommentEdit>
    {
        public void Configure(EntityTypeBuilder<Post_CommentEdit> builder)
        {
            builder.HasOne(x => x.PostComment)
                .WithMany(x => x.Edits)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}