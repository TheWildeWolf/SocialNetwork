using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class WorkDetailDto
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string JobTitle { get; set; }
        public string JobCategory { get; set; }
        public DateTime DateForm { get; set; }
        public DateTime? DateUpto { get; set; }
    }
}
