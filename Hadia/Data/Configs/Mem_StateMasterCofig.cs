using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Mem_StateMasterCofig : IEntityTypeConfiguration<Mem_StateMaster>
    {
        public void Configure(EntityTypeBuilder<Mem_StateMaster> builder)
        {
            builder.HasMany(x => x.Districts)
               .WithOne(x => x.State)
               .HasForeignKey(x => x.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
