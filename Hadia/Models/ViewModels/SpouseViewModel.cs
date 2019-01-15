using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class SpouseViewModel
    {
        public int Id { get; set; }
        public string SpouseName { get; set; }
        public int? SpouseAge { get; set; }
        [DisplayName("QualificationName")]
        public int? SpouseEducationId { get; set; }
        public string QualificationName { get; set; }
        public SelectList SpouseEduList { get; set; }
    }
}
