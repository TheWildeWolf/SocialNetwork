using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class ProfileEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("UgCollegeName")]
        public int? UgCollageId { get; set; }
        public string UgCollegeName { get; set; }
        public string Phone { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        //public MaritalStatus? MaritalStatus { get; set; }
        //public string SpouseName { get; set; }
        //public int? SpouseAge { get; set; }
        //[DisplayName("QualificationName")]
        //public int? SpouseEducationId { get; set; }
        //public string QualificationName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [DisplayName("DistrictName")]
        public int? DistrictId { get; set; }
        //public string DistrictName { get; set; }
        [DisplayName("Batch Name")]
        public int? GroupId { get; set; }
        //public string BatchName { get; set; }
        public string Email { get; set; }
        //public bool IsVarified { get; set; }
        [DisplayName("ChapterName")]
        public int ChapterId { get; set; }
        //public string ChapterName { get; set; }
        //public string PassoutYear { get; set; }

        public SelectList ChapterList { get; set; }
        public SelectList BatchList { get; set; }
        public SelectList UgCollegeList { get; set; }

    }
}
