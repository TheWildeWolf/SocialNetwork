using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;

namespace Hadia.Models.Dtos
{
    public class ProfileDetailViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePic { get; set; }
        public string UgCollegeName { get; set; }
        public string Phone { get; set; }
        public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public int? SpouseAge { get; set; }
        public string QualificationName { get; set; }
        public string DateOfBirth { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }
        public string BatchName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public bool IsVerified { get; set; }
        public string ChapterName { get; set; }
        public string DegreeName { get; set; }
        public string Rank { get; set; }
        public string PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string UniversityName { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CountryName { get; set; }
        public string JobTitle { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateUpto { get; set; }
        public List<KidViewDto> Kids { get; set; }
        public List<ProjectViewDto> Projects { get; set; }
        public List<EducationDetailDto> EducationDetails { get; set; }
        public List<WorkDetailDto> WorkDetails { get; set; }

    }
    public class KidViewDto
    {
        public int Id { get; set; }
        public string KidName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

    }
}
