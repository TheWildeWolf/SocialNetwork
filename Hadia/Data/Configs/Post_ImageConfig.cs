using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_ImageConfig : IEntityTypeConfiguration<Post_Image>
    {
        public void Configure(EntityTypeBuilder<Post_Image> builder)
        {
            builder.HasOne(x => x.DeletedBy)
                .WithMany(x => x.DeletedPostImages)
                .HasForeignKey(x => x.DLogin)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.PostMaster)
                .WithMany(x => x.PostImages)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
