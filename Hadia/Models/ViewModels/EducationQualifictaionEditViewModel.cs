using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class EducationQualifictaionEditMasterViewModel
    {
        public int QualificationId { get; set; }
        public int UniversityId { get; set; }
        public int MemberId { get; set; }
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }
        public int PassoutYear { get; set; }
        public SelectList QualificationList { get; set; }
        public SelectList UniversityList { get; set; }
        public List<EducationQualifictaionEditViewModel> Qualification { get; set; }
    }
    public class EducationQualifictaionEditViewModel
    {
        public int Id { get; set; }
        public int EducationQualificationId { get; set; }
        //  public int QualificationId { get; set; }
        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualification Required")]
        public string QualificationName { get; set; }
        [Required(ErrorMessage = "Select University")]
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        [Required(ErrorMessage = "Passout Year Required")]
        public int PassoutYear { get; set; }
       
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }

        public string Status { get; set; }
        public SelectList QualificationList { get; set; }
        public SelectList UniversityList { get; set; }
    }
}
