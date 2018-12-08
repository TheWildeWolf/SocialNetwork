using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class DistrictMasterViewModel
    {
        public int Id { get; set; }
        [Display(Name = "District Name")]
        [Required(ErrorMessage = "District Name Required")]
        public string DistrictName { get; set; }
        public int StateId { get; set; }
        [Display(Name ="State")]
        public SelectList StateList { get; set; }
    }
}
