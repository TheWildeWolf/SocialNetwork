using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class StateMasterViewModel
    {

        public int Id { get; set; }
        [Display(Name = "State ")]
        [Required]
        public string StateName { get; set; }
    }
}
