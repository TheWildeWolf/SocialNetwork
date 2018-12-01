using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_DonationConfig : IEntityTypeConfiguration<Post_Donation>
    {
        public void Configure(EntityTypeBuilder<Post_Donation> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.Donations)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Donations)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}