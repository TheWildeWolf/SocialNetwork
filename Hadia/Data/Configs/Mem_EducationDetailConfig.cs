using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_EducationDetailConfig : IEntityTypeConfiguration<Mem_EducationDetail>
    {
        public void Configure(EntityTypeBuilder<Mem_EducationDetail> builder)
        {
            builder.Property(x => x.PassoutYear).HasColumnType("date");
            builder.Property(x => x.Specialization).HasMaxLength(125);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.EducationDetails)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Qualification)
                .WithMany(x => x.EducationDetails)
                .HasForeignKey(x => x.EducationQualificationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.University)
                .WithMany(x => x.EducationDetails)
                .HasForeignKey(x => x.UniversityId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
