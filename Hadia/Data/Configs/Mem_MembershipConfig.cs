using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_MembershipConfig : IEntityTypeConfiguration<Mem_Membership>
    {
        public void Configure(EntityTypeBuilder<Mem_Membership> builder)
        {
            builder.HasOne(x => x.CreatedBy)
                .WithMany(x => x.MemberShipsCreated)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Member)
                .WithMany(x => x.MemberShips)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ModifiedBy)
                .WithMany(x => x.MemberShipsModified)
                .HasForeignKey(x => x.MLogin)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    

}
