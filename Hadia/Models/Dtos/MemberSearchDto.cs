using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Areas.Login.Models;

namespace Hadia.Models.Dtos
{
    public class MemberSearchDto : DataMemberDto
    {
        public string BatchName { get; set; }
        public string ChapterName { get; set; }
        public string UgCollege { get; set; }
        public string Phone { get; set; }
    }
}
