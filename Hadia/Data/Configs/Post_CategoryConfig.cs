using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_CategoryConfig : IEntityTypeConfiguration<Post_Category>
    {
        public void Configure(EntityTypeBuilder<Post_Category> builder)
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedCategories)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ModifiedCategories)
                .HasForeignKey(x => x.MLogin)
                .OnDelete(DeleteBehavior.ClientSetNull);

            
        }
    }
}