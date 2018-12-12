using System;

namespace Hadia.Models.DomainModels
{
    public class Mem_WorkDetail
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }

        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public DateTime DateForm { get; set; }
        public DateTime? DateUpto { get; set; }

        public DateTime CDate { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_CountryCode Country { get; set; }
        public Mem_JobCategoryMaster CategoryMaster { get; set; }
    }
}

