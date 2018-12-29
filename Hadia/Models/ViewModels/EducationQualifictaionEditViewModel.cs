using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class EducationQualifictaionEditMasterViewModel
    {
        public int QualificationId { get; set; }
        public int UniversityId { get; set; }

        public string Specialization { get; set; }
        public string PhdTopic { get; set; }
        public int PassoutYear { get; set; }
        public SelectList QualificationList { get; set; }
        public SelectList UniversityList { get; set; }
        public List<EducationQualifictaionEditViewModel> Qualification { get; set; }
    }
    public class EducationQualifictaionEditViewModel
    {
        public int EducationQualificationId { get; set; }

        public string QualificationName { get; set; }
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }

        public DateTime PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }

        public string Status { get; set; }
    }
}
