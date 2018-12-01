using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Sett_AdminActivityLogConfig : IEntityTypeConfiguration<Sett_AdminActivityLog>
    {
        public void Configure(EntityTypeBuilder<Sett_AdminActivityLog> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.AdminActivities)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}