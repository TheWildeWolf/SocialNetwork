using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class WorkDetailDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string JobTitle { get; set; }
        public int JobCategoryId { get; set; }
        public string JobCategory { get; set; }
        public string DateForm { get; set; }
        public string DateUpto { get; set; }
    }
}
