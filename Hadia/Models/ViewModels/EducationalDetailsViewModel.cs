using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class EducationalDetailsViewModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int EducationQualificationId { get; set; }
        public int UniversityId { get; set; }

        public DateTime PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }
        public DateTime CDate { get; set; }
        public SelectList QualificationList { get; set; }
        public SelectList UniversityList { get; set; }

    }
}
