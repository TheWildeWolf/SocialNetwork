using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.ViewModels
{
    public class PostReportViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Topic { get; set; }
        public string Voice { get; set; }
        public List<string>Images { get; set; }
        public string PostedBy { get; set; }
        public string GroupName { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReportedDate { get; set; }
        public string Narration { get; set; }
        public string ReportedBy { get; set; }

    }
}
