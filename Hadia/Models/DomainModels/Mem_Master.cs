using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int UgCollageId { get; set; }
        public int? DistrictId { get; set; }

        public string SpouseName { get; set; }
        public DateTime? SpouseAge { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }

        public int? SpouseEducationId { get; set; }
        public int? GroupId { get; set; }
        public bool IsGroupAdmin { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int? ActiveDeviceId { get; set; }

        public bool IsVarified { get; set; }

        public int? VarifiedBy { get; set; }
        public DateTime? VarifiedDate { get; set; }

        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }

        public Mem_Master VarifiedMember { get; set; }

        public Sett_DeviceInfoLog ActiveDevice { get; set; }

        public Mem_UgColleges UgCollege { get; set; }
        public Mem_DistrictMaster District { get; set; }
        public Mem_AdminPrivilage Privilage { get; set; }
        public Mem_SpouseEducationMaster SpouseEducation { get; set; }
        public Post_GroupMaster MainGroup { get; set; }

        public ICollection<Post_Comment> PostComments { get; set; } 
        public ICollection<Post_GroupMember> MembershipInGroups { get; set; }

        public ICollection<Post_CommentView> ViewedComments { get; set; }
        public ICollection<Mem_Master> VarifiedMembers { get; set; }
        public ICollection<Mem_EducationalQualificationMaster> EducationalQualificationMasters { get; set; }
        public ICollection<Mem_SpouseEducationMaster> SpouseEducationMasters { get; set; }
        public ICollection<Mem_StateMaster> StateMasters { get; set; }
        public ICollection<Mem_DistrictMaster> DistrictMasters { get; set; }
        public ICollection<Mem_UniversityMaster> UniversityMasters { get; set; }
        public ICollection<Mem_Photo> Photos { get; set; }
        public ICollection<Mem_Contanct> Contacts { get; set; }
        public ICollection<Mem_UgColleges> UgColleges { get; set; }
        public ICollection<Mem_EducationDetail> EducationDetails { get; set; }
        public ICollection<Mem_Kid> Kids { get; set; }
        public ICollection<Mem_WorkDetail> WorkDetails { get; set; }
        public ICollection<Mem_InterestedArea> InterestedAreas { get; set; }
        public ICollection<Mem_MyNetwork> Networks { get; set; }
        public ICollection<Mem_MyNetwork> MemberInNetworks { get; set; }
        public ICollection<Mem_Membership> MemberShips { get; set; }
        public ICollection<Mem_Membership> MemberShipsCreated { get; set; }
        public ICollection<Mem_Membership> MemberShipsModified { get; set; }
        public ICollection<Mem_ProjectWork> Projects{ get; set; }
        public ICollection<Mem_JobCategoryMaster> CreatedJobCategoryMasters { get; set; }

        public ICollection<Post_GroupMaster> CreatedGroups { get; set; }
        public ICollection<Post_GroupMember> MembersAdded { get; set; }
        public ICollection<Post_GroupMember> MembersModified { get; set; }
        public ICollection<Post_ChapterLeader> LeaderInChapters { get; set; }
        public ICollection<Post_ChapterLeader> CreatedChapterLeaders { get; set; }
        public ICollection<Post_InterestedAreaMaster> InterestedAreaMasterCreated { get; set; }
        public ICollection<Post_InterestedArea> CreatedinterestAreas { get; set; }

        public ICollection<Post_Master> CreatedPosts { get; set; }
        public ICollection<Post_Master> DeletedPosts { get; set; }

        public ICollection<Res_Master> PostedResources { get; set; }
        public ICollection<Res_Master> ResourcesDeleted { get; set; }
        public ICollection<Res_Views> ResourcesViews { get; set; }

        public ICollection<Post_Image> DeletedPostImages { get; set; }
        public ICollection<Post_Comment> DeletedComments { get; set; }
        public ICollection<Post_Like> LikedPosts { get; set; }

        public ICollection<Post_CommentsLike> PostCommentsLikes { get; set; }

        public ICollection<Post_ReportReason> CreatedPostReportReasons { get; set; }
        public ICollection<Post_ReportReason> ModifiedPostReportReasons { get; set; }
        
        public ICollection<Haf_YearMaster> HadiyaYearAdded { get; set; }
        public ICollection<Haf_YearMaster> HadiyaYearModified { get; set; }

        public ICollection<Post_Report> ReportedPosts { get; set; }
        public ICollection<Haf_Master> HAFmember { get; set; }
        public ICollection<Haf_Master> HAFCreatedBy { get; set; }
        public ICollection<Haf_Master> HAFModifiedBy { get; set; }
        public ICollection<Post_View> ViewedPosts { get; set; }

        public ICollection<Com_Master> MemPresident { get; set; }
        public ICollection<Com_Master> MemVice1 { get; set; }
        public ICollection<Com_Master> MemVice2 { get; set; }
        public ICollection<Com_Master> MemSecretery { get; set; }
        public ICollection<Com_Master> MemJointSecr1 { get; set; }
        public ICollection<Com_Master> MemJointSecr2 { get; set; }
        public ICollection<Com_Master> MemTreasurer { get; set; }
        public ICollection<Com_Master> MemCreatedBy { get; set; }
        public ICollection<Com_Master> MemModifiedBy { get; set; }

        public ICollection<Com_ExecutiveMember> ExMember { get; set; }
        public ICollection<Com_ExecutiveMember> ExCreatedBy { get; set; }
        public ICollection<Com_ExecutiveMember> ExModifiedBy { get; set; }

        public ICollection<Post_Follow> FollowedPosts { get; set; }
        public ICollection<Post_Donation> Donations { get; set; }
        public ICollection<Post_Category> CreatedCategories { get; set; }
        public ICollection<Post_Category> ModifiedCategories { get; set; }
        public ICollection<Post_EventRegistration> EventRegistrations { get; set; }

        public ICollection<Post_Categorypermission> CreatedPermissions { get; set; }

        public ICollection<Post_Categorypermission> ModifiedPermissions { get; set; }

        public ICollection<Post_Categorypermission> Categorypermissions { get; set; }
        //Job
        public ICollection<Job_Master> PostedJobs { get; set; }
        public ICollection<Job_Master> AppointedJobs { get; set; }
        public ICollection<Job_Master> DeletedJobs { get; set; }
        public ICollection<Job_View> ViewedJobs { get; set; }

        //Sett
        public ICollection<Sett_PrivacySetting> PrivacySettings { get; set; }
        public ICollection<Sett_AdminActivityLog> AdminActivities { get; set; }
        public ICollection<Sett_GroupAdminHistory> AdminHistory { get; set; }
        public ICollection<Sett_DeviceInfoLog> DeviceInfoLogs { get; set; }
        public ICollection<Sett_LoginLog> LoginLogs { get; set; }
        
    }

    public enum MaritalStatus : byte
    {
        [DisplayName("Single")]
        Single = 1,
        [DisplayName("Married")]
        Married = 2,
        [DisplayName("Divorced")]
        Divorced = 3
    }

}
