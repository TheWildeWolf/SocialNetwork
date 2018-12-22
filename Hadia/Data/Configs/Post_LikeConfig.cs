using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_LikeConfig : IEntityTypeConfiguration<Post_Like>
    {
        public void Configure(EntityTypeBuilder<Post_Like> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.LikedPosts)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
