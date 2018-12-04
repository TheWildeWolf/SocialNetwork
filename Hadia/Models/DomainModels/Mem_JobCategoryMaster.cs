using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_JobCategoryMaster
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public ICollection<Mem_WorkDetail> WorkDetails { get; set; }
    }
}
