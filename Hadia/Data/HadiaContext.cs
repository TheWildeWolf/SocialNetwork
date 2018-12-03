using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public DbSet<Mem_Photo> Mem_Photos { get; set; }
        public DbSet<Mem_Contanct> Mem_Contacts { get; set; }
        public DbSet<Mem_EducationDetail> Mem_EducationDetails { get; set; }
        public DbSet<Mem_AdminPrivilage> Mem_AdminPrivilages { get; set; }

        public DbSet<Post_GroupMember> Post_GroupMembers { get; set; }
        public DbSet<Post_GroupMaster> Post_GroupMasters { get; set; }

        public DbSet<Mem_Kid> Mem_Kids { get; set; }
        public DbSet<Mem_WorkDetail> Mem_WorkDetails { get; set; }
        public DbSet<Mem_InterestedArea> Mem_InterestedAreas { get; set; }
        public DbSet<Mem_MyNetwork> Mem_MyNetworks { get; set; }
        public DbSet<Mem_Membership> Mem_Memberships { get; set; }

        public DbSet<Post_ChapterLeader> Post_ChapterLeaders { get; set; }
        public DbSet<Post_InterestedAreaMaster> Post_InterestedAreaMasters { get; set; }
        public DbSet<Post_InterestedArea> Post_InterestedAreas { get; set; }
        public DbSet<Post_Master> Post_Masters { get; set; }
        public DbSet<Post_Image> Post_Images { get; set; }
        public DbSet<Res_Master> Res_Masters { get; set; }
        public DbSet<Res_Views>Res_Views  { get; set; }
        public DbSet<Post_Comment> Post_Comments { get; set; }
        public DbSet<Post_Like> Post_Likes { get; set; }
        public DbSet<Post_CommentsLike> Post_CommentsLikes { get; set; }
        public DbSet<Post_ReportReason> Post_ReportReasons { get; set; }
        public DbSet<Haf_YearMaster> Haf_YearMasters { get; set; }
        public DbSet<Post_Report> Post_Reports { get; set; }
        public DbSet<Post_Edit> Post_Edits { get; set; }
        public DbSet<Haf_Master> Haf_Masters { get; set; }
        public DbSet<Com_Master> Com_Masters { get; set; }
        public DbSet<Post_View> Post_Views { get; set; }
        public DbSet<Com_ExecutiveMember> Com_ExecutiveMembers { get; set; }
        public DbSet<Post_CommentEdit> Post_CommentEdits { get; set; }
        public DbSet<Post_Follow> Post_Followers { get; set; }
        public DbSet<Post_Donation> Post_Donations { get; set; }
        public DbSet<Post_Category> Post_Categories { get; set; }
        public DbSet<Post_Categorypermission> Post_Categorypermissions { get; set; }
        public DbSet<Post_EventRegistration> Post_EventRegistrations { get; set; }
        public DbSet<Sett_PrivacyInfoCategory> Sett_PrivacyInfoCategories { get; set; }
        public DbSet<Sett_PrivacySetting> Sett_PrivacySettings { get; set; }
        public DbSet<Sett_GroupAdminHistory> Sett_GroupAdminHistories { get; set; }
        public DbSet<Sett_AdminActivityLog> Sett_AdminActivityLogses { get; set; }
        public DbSet<Sett_DeviceInfoLog> Sett_DeviceInfoLogs { get; set; }
        public DbSet<Sett_LoginLog> Sett_LoginLogs { get; set; }
        
        public DbSet<Job_Master> Job_Masters { get; set; }

        public DbSet<Job_View> Job_Views { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new Mem_MasterConfig());
            //modelBuilder.ApplyConfiguration(new Mem_StateMasterCofig());
            //modelBuilder.ApplyConfiguration(new Post_GroupMasterConfig());
            //modelBuilder.ApplyConfiguration(new Post_GroupMembersConfig());
            //modelBuilder.ApplyConfiguration(new Mem_PhotosConfig());
            //modelBuilder.ApplyConfiguration(new Mem_CountryCodeConfig());

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();


                foreach (var type in typesToRegister)
                {
                    dynamic configurationInstance = Activator.CreateInstance(type);
                    modelBuilder.ApplyConfiguration(configurationInstance);
                }
                
 


        }
    }



}
