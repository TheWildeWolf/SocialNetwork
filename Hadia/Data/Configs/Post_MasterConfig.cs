using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_MasterConfig : IEntityTypeConfiguration<Post_Master>
    {
        public void Configure(EntityTypeBuilder<Post_Master> builder)
        {
            builder.HasOne(x => x.OpendBy)
                .WithMany(x => x.CreatedPosts)
                .HasForeignKey(x => x.OpnedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.GroupMaster)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeletedBy)
                .WithMany(x => x.DeletedPosts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
