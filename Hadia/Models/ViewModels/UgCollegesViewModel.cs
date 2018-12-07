using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class UgCollegesViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ug College Name")]
        [Required(ErrorMessage = "Ug College Name Required")]
        public string UgCollegeName { get; set; }
    }
}
