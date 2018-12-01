using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_ReportReasonReasonConfig : IEntityTypeConfiguration<Post_ReportReason>
    {
        public void Configure(EntityTypeBuilder<Post_ReportReason> builder)
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedPostReportReasons)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.ModifiedPostReportReasons)
                .HasForeignKey(x => x.MLogin)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}