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
        public MaritalStatus Type { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int? UgCollageId { get; set; }
        public int? DistrictId { get; set; }

        public string SpouseName { get; set; }
        public DateTime? SpouseAge { get; set; }

        public int? SpouseEducationId { get; set; }
        public int? GroupId { get; set; }
        public bool IsGroupAdmin { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool IsVarified { get; set; }

        public int? VarifiedBy { get; set; }
        public DateTime? VarifiedDate { get; set; }

        public Mem_Master VarifiedMember { get; set; }

        public Mem_UgColleges UgCollege { get; set; }
        public Mem_DistrictMaster District { get; set; }
        public Mem_AdminPrivilage Privilage { get; set; }
        public Mem_SpouseEducationMaster SpouseEducation { get; set; }
        public Post_GroupMaster MainGroup { get; set; }

        public ICollection<Mem_Master> VarifiedMembers { get; set; }
        public ICollection<Mem_EducationalQualificationMaster> EducationalQualificationMasters { get; set; }
        public ICollection<Mem_SpouseEducationMaster> SpouseEducationMasters { get; set; }
        public ICollection<Mem_StateMaster> StateMasters { get; set; }
        public ICollection<Mem_DistrictMaster> DistrictMasters { get; set; }
        public ICollection<Mem_UniversityMaster> UniversityMasters { get; set; }
        public ICollection<Mem_Photo> Photos { get; set; }
        public ICollection<Mem_MemberContanct> Contacts { get; set; }
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

        public ICollection<Post_GroupMaster> CreatedGroups { get; set; }
        public ICollection<Post_GroupMember> MembersAdded { get; set; }
        public ICollection<Post_GroupMember> MembersModified { get; set; }
        public ICollection<Post_ChapterLeader> LeaderInChapters { get; set; }
        public ICollection<Post_ChapterLeader> CreatedChapterLeaders { get; set; }
        public ICollection<Post_InterestedAreaMaster> InterestedAreaMasterCreated { get; set; }
        public ICollection<Post_InterestedArea> CreatedinterestAreas { get; set; }

        public ICollection<Resources> Resourceses { get; set; }
        public ICollection<Resources> ResourcesesDeleted{ get; set; }
        public ICollection<Res_Views> ResourcesViews { get; set; }


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
