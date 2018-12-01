using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_InterestedAreaMaster
    {
        public int Id { get; set; }
        public string InterestName { get; set; }
        public DateTime CDate { get; set; }
        public int CLogin { get; set; }


        public Mem_Master CreatedBy { get; set; }
        public ICollection<Post_InterestedArea> InterestedAreas { get; set; }
    }
}
