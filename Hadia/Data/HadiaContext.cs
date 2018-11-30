using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Data.Configs;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hadia.Data
{
    public class HadiaContext : DbContext
    {
        public HadiaContext(DbContextOptions<HadiaContext> options) : base(options)
        {
        }

        public DbSet<Mem_Master> Mem_Masters { get; set; }
        public DbSet<Mem_EducationalQualificationMaster> Mem_EducationalQualifications { get; set; }
        public DbSet<Mem_SpouseEducationMaster> Mem_SpouseEducationMasters { get; set; }
        public DbSet<Mem_StateMaster> Mem_StateMasters { get; set; }
        public DbSet<Mem_DistrictMaster> Mem_DistrictMasters { get; set; }
        public DbSet<Mem_UniversityMaster> Mem_UniversityMasters { get; set; }
        public DbSet<Mem_CountryCode> Mem_CountryCodes { get; set; }
        public DbSet<Mem_UgColleges> Mem_UgColleges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mem_MasterConfig());
            modelBuilder.ApplyConfiguration(new Mem_StateMasterCofig());
            modelBuilder.ApplyConfiguration(new Mem_CountryCodeConfig());
        }
    }



}
