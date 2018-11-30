using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_InterestedAreaConfig : IEntityTypeConfiguration<Mem_InterestedArea>
    {
        public void Configure(EntityTypeBuilder<Mem_InterestedArea> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.InterestedAreas)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
