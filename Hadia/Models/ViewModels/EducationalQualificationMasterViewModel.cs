using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels.ViewModels
{
    public class EducationalQualificationMasterViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Degree Name")]
        [Required(ErrorMessage = "Degree Name Required")]
        public string DegreeName { get; set; }

        [Required(ErrorMessage = "Rank Required", AllowEmptyStrings = false)]
        public int Rank { get; set; }
        [Display(Name = "Is This Phd?")]
        public bool IsPhd { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }
    }
}
