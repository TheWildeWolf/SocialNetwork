using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_UniversityMaster
    {
        public int Id { get; set; }
        public string UniversityName  { get; set; }
        public int CountryId { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public Mem_CountryCode CountryCode { get; set; }

        public ICollection<Mem_EducationDetail> EducationDetails { get; set; }


    }
}
