using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_MyNetworkConfig : IEntityTypeConfiguration<Mem_MyNetwork>
    {
        public void Configure(EntityTypeBuilder<Mem_MyNetwork> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.Networks)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.NetworkMember)
                .WithMany(x => x.MemberInNetworks)
                .HasForeignKey(x => x.NetworkMemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    

}
