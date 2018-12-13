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
        public GroupType Type { get; set; }
        [Display(Name = "Status")]
        public GroupPrivacy OpenOrClosed { get; set; }
        public string Description { get; set; }
        [Display(Name = "Formed On")]
        public DateTime? FormedOn { get; set; }
       
    }
}
