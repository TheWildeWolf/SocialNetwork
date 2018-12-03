using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_ContactConfig : IEntityTypeConfiguration<Mem_Contanct>
    {
        public void Configure(EntityTypeBuilder<Mem_Contanct> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CountryCode)
                .WithMany(x => x.Contancts)
                .HasForeignKey(x => x.ConuntryCodeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
