using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_PhotosConfig : IEntityTypeConfiguration<Mem_Photo>
    {
        public void Configure(EntityTypeBuilder<Mem_Photo> builder)
        {
            builder.HasOne(x => x.Member)
                .WithMany(x => x.Photos)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
