using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_KidsConfig : IEntityTypeConfiguration<Mem_Kid>
    {
        public void Configure(EntityTypeBuilder<Mem_Kid> builder)
        {
            builder.Property(x => x.KidName).HasMaxLength(120);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.Kids)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Age).HasColumnType("date");
        }
    }
}
