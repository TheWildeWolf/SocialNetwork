using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_CountryCode
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string  TimeZone  { get; set; }
        public DateTime  CDate { get; set; }

        public ICollection<Mem_UniversityMaster> UniversityMasters { get; set; }
        public ICollection<Mem_MemberContanct> Contancts { get; set; }
        public ICollection<Mem_WorkDetail> WorkersInCountry { get; set; }
    }
}
