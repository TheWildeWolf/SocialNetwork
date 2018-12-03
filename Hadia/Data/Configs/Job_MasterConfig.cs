using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Job_MasterConfig : IEntityTypeConfiguration<Job_Master>
    {
        public void Configure(EntityTypeBuilder<Job_Master> builder)
        {
            builder.HasOne(x => x.PostedBy)
                .WithMany(x => x.PostedJobs)
                .HasForeignKey(x => x.PostedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AppointedMember)
                .WithMany(x => x.AppointedJobs)
                .HasForeignKey(x => x.AppointedMemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.DeletedBy)
                .WithMany(x => x.DeletedJobs)
                .HasForeignKey(x => x.DLogin)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}