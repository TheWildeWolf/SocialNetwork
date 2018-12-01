using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_CommentsLikeConfig : IEntityTypeConfiguration<Post_CommentsLike>
    {
        public void Configure(EntityTypeBuilder<Post_CommentsLike> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.PostCommentsLikes)
                .HasForeignKey(x=>x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Comment)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}