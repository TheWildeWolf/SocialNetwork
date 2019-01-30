using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class ReportsViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string  Post { get; set; }

        public string  ReportedBy { get; set; }

        public string  Reason { get; set; }

        public string Narration { get; set; }

      
    }
}
