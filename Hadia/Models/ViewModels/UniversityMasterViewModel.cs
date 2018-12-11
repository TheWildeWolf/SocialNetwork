using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class UniversityMasterViewModel
    {
        public int Id { get; set; }
        [Display(Name = "University Name")]
        [Required(ErrorMessage = "University Name Required")]
        public string UniversityName { get; set; }
        [Required(ErrorMessage = "Select Country")]
        public int CountryId { get; set; }
        [Display(Name = "Country")]
        public SelectList CountryList { get; set; }
        public string CountryName { get; set; }
    }
}
