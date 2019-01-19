using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Areas.Login.Models
{
    public class PasswordViewModel
    {
        public string Key { get; set; }
        [Display(Name = "New Password")]
        [Required]
        public string NewPassword { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
