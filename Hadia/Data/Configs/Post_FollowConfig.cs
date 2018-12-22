using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_FollowConfig : IEntityTypeConfiguration<Post_Follow>
    {
        public void Configure(EntityTypeBuilder<Post_Follow> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Member)
                .WithMany(x => x.FollowedPosts)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}