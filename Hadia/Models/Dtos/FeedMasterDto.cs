using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class FeedMasterDto
    {
        public int PageNo { get; set; }
        public List<FeedDto> Feeds { get; set; }
    }
}
