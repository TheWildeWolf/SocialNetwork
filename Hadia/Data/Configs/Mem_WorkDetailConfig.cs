using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_WorkDetailConfig : IEntityTypeConfiguration<Mem_WorkDetail>
    {
        public void Configure(EntityTypeBuilder<Mem_WorkDetail> builder)
        {
            builder.Property(x => x.CompanyName).HasMaxLength(50);
            builder.Property(x => x.Location).HasMaxLength(50);

            builder.Property(x => x.JobTitle).HasMaxLength(100);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.WorkDetails)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Country)
                .WithMany(x => x.WorkersInCountry)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
