using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class MemberViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? UgCollageId { get; set; }
        public string Phone { get; set; }
        public int? GroupId { get; set; } 
        public string Email { get; set; }
        public bool IsVarified { get; set; }
        public string UgCollegeName { get; set; }
        public string GroupName { get; set; }
    }
}
