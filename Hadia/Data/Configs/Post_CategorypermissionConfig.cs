using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_CategorypermissionConfig : IEntityTypeConfiguration<Post_Categorypermission>
    {
        public void Configure(EntityTypeBuilder<Post_Categorypermission> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Categorypermissions)
                .HasForeignKey(x => x.PostCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedPermissions)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ModifiedPermissions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.Categorypermissions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}