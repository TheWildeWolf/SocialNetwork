using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Data.Configs
{
    public class HadiaCommitteConfig : IEntityTypeConfiguration<HadiaCommittee>
    {
        public void Configure(EntityTypeBuilder<HadiaCommittee> builder)
        {
          
        }
    }
}
