using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hadia.Data.Configs
{
    public class Mem_MasterConfig : IEntityTypeConfiguration<Mem_Master>
    {
        public void Configure(EntityTypeBuilder<Mem_Master> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();

            builder.Property(x => x.AdNo).HasMaxLength(128).IsRequired();

            builder.Property(x => x.PresentAddress).HasMaxLength(500);
            builder.Property(x => x.Email).HasMaxLength(128);
            builder.Property(x => x.PermanentAddress).HasMaxLength(500);
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.CountryCode).HasMaxLength(8).IsRequired();

            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();

            builder.Property(x => x.SpouseName).HasMaxLength(128);
            builder.Property(x => x.SpouseAge).HasColumnType("date");

            builder.HasMany(x => x.EducationalQualificationMasters)
                    .WithOne(x => x.CreatedBy)
                    .HasForeignKey(x => x.CLogin);

            builder.HasIndex(x=>x.Email).IsUnique();

            builder.HasMany(x => x.SpouseEducationMasters)
            .WithOne(x => x.CreatedBy)
            .HasForeignKey(x => x.CLogin);

            builder.HasMany(x => x.StateMasters)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CLogin);

            builder.HasMany(x => x.DistrictMasters)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CLogin);

            builder.HasMany(x => x.UniversityMasters)
              .WithOne(x => x.CreatedBy)
              .HasForeignKey(x => x.CLogin);

            builder.HasMany(x => x.UgColleges)
              .WithOne(x => x.CreatedBy)
              .HasForeignKey(x => x.CLogin);

            builder.HasOne(x=>x.Privilage)
                .WithOne(x=>x.Member);

            builder.HasOne(x => x.UgCollege)
                .WithMany(x => x.MembersInUg)
                .HasForeignKey(x => x.UgCollageId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.District)
                .WithMany(x => x.MembersInDistrict)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.SpouseEducation)
                .WithMany(x => x.MembersSpouses)
                .HasForeignKey(x => x.SpouseEducationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.MainGroup)
                .WithMany(x => x.MembersInBatch)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.VarifiedMember)
                .WithMany(x => x.VarifiedMembers)
                .HasForeignKey(x => x.VarifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.CreatedJobCategoryMasters)
                .WithOne(x => x.CreatedBy)
                .HasForeignKey(x => x.CLogin)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.DateOfBirth).HasColumnType("date");



        }
    }
}
