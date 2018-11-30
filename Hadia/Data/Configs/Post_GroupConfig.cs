using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Post_GroupMasterConfig : IEntityTypeConfiguration<Post_GroupMaster>
    {
        public void Configure(EntityTypeBuilder<Post_GroupMaster> builder)
        {
            builder.Property(x=>x.)
        }
    }
}
