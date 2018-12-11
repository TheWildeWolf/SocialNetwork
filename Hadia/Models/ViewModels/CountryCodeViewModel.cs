using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class CountryCodeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public string CountryName { get; set; }
        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Country Code Required")]
        public string CountryCode { get; set; }
        [Display(Name = "Time Zone")]
        [Required(ErrorMessage = "Time Zone Required")]
        public string TimeZone { get; set; }
    }
}
