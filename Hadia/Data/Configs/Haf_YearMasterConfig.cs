using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class Haf_YearMasterMasterConfig : IEntityTypeConfiguration<Haf_YearMaster>
    {
        public void Configure(EntityTypeBuilder<Haf_YearMaster> builder)
        {
            builder.HasOne(x => x.YearAddedBy)
                .WithMany(x => x.HadiyaYearAdded)
                .HasForeignKey(x => x.CLogin);

            builder.HasOne(x => x.YearModifiedBy)
                .WithMany(x => x.HadiyaYearModified)
                .HasForeignKey(x => x.MLogin);

        }
    }
}
