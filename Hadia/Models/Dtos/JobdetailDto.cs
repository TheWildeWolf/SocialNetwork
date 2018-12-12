using System;

namespace Hadia.Models.Dtos
{
    public class JobdetailDto
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }

        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public DateTime DateForm { get; set; }
        public DateTime? DateUpto { get; set; }
    }
}