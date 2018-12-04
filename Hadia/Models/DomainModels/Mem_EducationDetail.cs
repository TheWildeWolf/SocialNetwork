using System;

namespace Hadia.Models.DomainModels
{
    public class Mem_EducationDetail
    {
        public int Id { get; set; }
        public int MemberId { get; set; }

        public int EducationQualificationId { get; set; }
        public int UniversityId { get; set; }

        public DateTime PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }
        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_EducationalQualificationMaster Qualification { get; set; }
        public Mem_UniversityMaster University { get; set; }
    }

}
