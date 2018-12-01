using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hadia.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Mem_CountryCodeConfig : IEntityTypeConfiguration<Mem_CountryCode>
    {

        public void Configure(EntityTypeBuilder<Mem_CountryCode> builder)
        {
            builder.HasMany(x => x.UniversityMasters)
                .WithOne(x => x.CountryCode)
                .HasForeignKey(x => x.CountryId)
             .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
