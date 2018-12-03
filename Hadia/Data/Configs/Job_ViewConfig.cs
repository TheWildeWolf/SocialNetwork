using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Job_ViewConfig : IEntityTypeConfiguration<Job_View>
    {
        public void Configure(EntityTypeBuilder<Job_View> builder)
        {
            builder.HasOne(x => x.Job)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.MasterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.ViewedJobs)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}