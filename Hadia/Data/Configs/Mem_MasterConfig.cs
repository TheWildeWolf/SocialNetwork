using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Prof_MemberConfig : IEntityTypeConfiguration<Mem_Master>
    {
        public void Configure(EntityTypeBuilder<Mem_Master> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.AdNo).IsRequired();
            builder.Property(x => x.PresentAddress).IsRequired();

            builder.HasMany(x => x.EducationalQualifications)
                    .WithOne(x => x.CreatedBy)
                    .HasForeignKey(x => x.CLogin);
                
        }
    }
}
