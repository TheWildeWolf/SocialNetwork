using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class AuthSettingsViewModel
    {
        [Display(Name = "Current Password")]
        [Required]
        public string CurrentPassword { get; set; }

        [Display(Name = "New Password")]
        [Required]

        public string NewPassword { get; set; }
        [Display(Name = "Confirm Password")]
        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}
