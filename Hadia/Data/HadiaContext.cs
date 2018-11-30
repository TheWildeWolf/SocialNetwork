﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Data.Configs;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Data
{
    public class HadiaContext : DbContext
    {
        public HadiaContext(DbContextOptions<HadiaContext> options) : base(options)
        {
        }

        public DbSet<Mem_Master> Mem_Masters { get; set; }
        public DbSet<Mem_EducationalQualification> Mem_EducationalQualifications { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Prof_MemberConfig());
        }
    }

}
