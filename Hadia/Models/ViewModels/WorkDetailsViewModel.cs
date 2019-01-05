using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class WorkDetailsViewModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int CountryId { get; set; }
        public SelectList CountryList { get; set; }
        public string CountryName { get; set; }
        public string JobTitle { get; set; }
        //public int JobCategoryId { get; set; }
        public DateTime DateForm { get; set; }
        public DateTime? DateUpto { get; set; }

        public Mem_Master Member { get; set; }
        public Mem_CountryCode Country { get; set; }


    }
}
