using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_EventRegistrationConfig : IEntityTypeConfiguration<Post_EventRegistration>
    {
        public void Configure(EntityTypeBuilder<Post_EventRegistration> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.EventRegistrations)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.EventRegistrations)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}