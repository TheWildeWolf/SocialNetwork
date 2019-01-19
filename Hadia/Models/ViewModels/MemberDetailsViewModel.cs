using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class MemberDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("UgCollegeName")]
        public int? UgCollageId { get; set; }
        public string UgCollegeName { get; set; }
        public string Phone { get; set; }

        private string _photo;

        public string Photo
        {
            get => _photo;
            set => _photo = string.IsNullOrEmpty(value) ? "/global_assets/images/placeholders/placeholder.jpg" : "/Profile/" + value;
        }
      //  public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        //public MaritalStatus? MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public int? SpouseAge { get; set; }
        [DisplayName("QualificationName")]
        public int? SpouseEducationId { get; set; }
        public string QualificationName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("DistrictName")]
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        [DisplayName("GroupName")]
        public int? GroupId { get; set; }
        public string BatchName { get; set; }
        public string Email { get; set; }
        public bool IsVarified { get; set; }
        [DisplayName("ChapterName")]
        public int ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string DegreeName { get; set; }
        public string Rank { get; set; }
        public string PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string UniversityName { get; set; }
        public SelectList KidsList { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CountryName { get; set; }
        public string JobTitle { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateUpto { get; set; }
        public SelectList SpouseEduList { get; set; }

        public ICollection<KidViewModel> Kids { get; set; }
        public ICollection<Mem_EducationDetail> EducationDetails { get; set; }
        public ICollection<Mem_EducationalQualificationMaster> EducationalQualificationMasters { get; set; }
        public ICollection<Mem_WorkDetail> WorkDetails { get; set; }
        public ICollection<Mem_CountryCode> Country { get; set; }
        public ICollection<Mem_ProjectWork> Projects { get; set; }
    }
   
    public class KidViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Kid Name Required")]
        public string KidName { get; set; }
        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }
       
        public GenderType Gender { get; set; }
    }
    

}
