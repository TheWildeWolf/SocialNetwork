using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class SpouseEducationMasterViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Qualification Name")]
        [Required(ErrorMessage = "Qualification Name Required")]
        public string QualificationName { get; set; }
    }
}
