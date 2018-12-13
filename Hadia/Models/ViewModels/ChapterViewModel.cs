using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class ChapterViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Chapter Name")]
        [Required(ErrorMessage = "Chapter Name Required")]
        public string GroupName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Formed On")]
        [Required(ErrorMessage = "Formed On Required")]
        public DateTime? FormedOn { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ImageLocation { get; set; }
        public string GroupImage { get; set; }
    }
}
