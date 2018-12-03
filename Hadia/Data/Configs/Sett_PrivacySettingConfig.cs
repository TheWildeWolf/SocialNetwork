using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Sett_PrivacySettingConfig : IEntityTypeConfiguration<Sett_PrivacySetting>
    {
        public void Configure(EntityTypeBuilder<Sett_PrivacySetting> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.PrivacySettings)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.PrivacySettings)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}