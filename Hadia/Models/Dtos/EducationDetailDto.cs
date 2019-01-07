using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class EducationDetailDto
    {
        public string Qualification { get; set; }
        public string University { get; set; }
        public int PassoutYear { get; set; }
        public string Specialization { get; set; }
        public string PhdTopic { get; set; }
    }
}
