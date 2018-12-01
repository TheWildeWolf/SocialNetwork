using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_ReportConfig : IEntityTypeConfiguration<Post_Report>
    {
        public void Configure(EntityTypeBuilder<Post_Report> builder)
        {
            builder.HasOne(x => x.PostMaster)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReportedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ReportReason)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReasonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PostMaster)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}