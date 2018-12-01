using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_EditConfig : IEntityTypeConfiguration<Post_Edit>
    {
        public void Configure(EntityTypeBuilder<Post_Edit> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.EditedPosts)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}