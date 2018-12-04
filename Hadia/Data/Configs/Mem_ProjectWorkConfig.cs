using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Mem_ProjectWorkConfig : IEntityTypeConfiguration<Mem_ProjectWork>
    {
        public void Configure(EntityTypeBuilder<Mem_ProjectWork> builder)
        {
            builder.HasOne(x => x.Member)
               .WithMany(x => x.Projects)
               .HasForeignKey(x => x.MemberId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
