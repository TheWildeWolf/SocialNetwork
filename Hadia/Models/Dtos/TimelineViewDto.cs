using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class TimelineViewDto
    {
        public string Topic { get; set; }
        public List<string> Images { get; set; }
        public string Voice { get; set; }
        public GroupType Type { get; set; }
        public string GroupName { get; set; }
        public string Date { get; set; }
    }
}
