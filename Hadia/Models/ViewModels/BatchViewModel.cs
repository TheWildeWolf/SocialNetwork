using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class BatchViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Batch Name")]
        [Required(ErrorMessage = "Batch Name Required")]
        public string GroupName { get; set; }
        //public GroupType Type { get; set; }
        //[Display(Name = "Status")]
        //public GroupPrivacy OpenOrClosed { get; set; }
        public string Description { get; set; }
        //[Display(Name = "Formed On")]
        //public DateTime? FormedOn { get; set; }
        [Required(ErrorMessage = "Pass out Year Required")]
        [Display(Name = "Pass out Year")]
        public string PassoutYear { get; set; }
    }
    public enum GroupType : byte
    {
        Chapter = 1,
        Group = 2,
        Batch = 3

    }

    public enum GroupPrivacy : byte
    {
        Open = 1,
        Closed = 2
    }

}
