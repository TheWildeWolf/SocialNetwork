using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class KidsViewModel
    {

      
        public int MemberId { get; set; }
        public string KidName { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }
        public List<KidsListViewModel> KidsList { get; set; }
    }
    public class KidsListViewModel
    {
        public int Id { get; set; }
        public string KidName { get; set; }
        public DateTime Age { get; set; }
        public string Gender { get; set; }
    }
}
