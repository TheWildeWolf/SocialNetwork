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
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Group Name Required")]
        public string GroupName { get; set; }
        public GroupType Type { get; set; }
        public GroupPrivacy OpenOrClosed { get; set; }
        public string Description { get; set; }
        public DateTime? FormedOn { get; set; }
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
