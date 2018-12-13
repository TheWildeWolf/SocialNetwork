using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class MemberViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("UgCollegeName")]
        public int? UgCollageId { get; set; }
        public string Phone { get; set; }
        [DisplayName("GroupName")]
        public int? GroupId { get; set; } 
        public string Email { get; set; }
        public bool IsVarified { get; set; }
        public string UgCollegeName { get; set; }
        public string ChapterName { get; set; }
        public string BatchName { get; set; }

    }
}
