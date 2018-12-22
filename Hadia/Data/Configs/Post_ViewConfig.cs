using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_ViewConfig : IEntityTypeConfiguration<Post_View>
    {
        public void Configure(EntityTypeBuilder<Post_View> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.ViewedPosts)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostViews)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}