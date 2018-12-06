using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_SpouseEducationMaster
    {
        public int Id { get; set; }
        [Display(Name="Qualification Name")]
        [Required (ErrorMessage ="Qualification Name Required")]
        public string  QualificationName { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }
         
        public Mem_Master CreatedBy { get; set; }

        public ICollection<Mem_Master> MembersSpouses { get; set; }
    }
}
