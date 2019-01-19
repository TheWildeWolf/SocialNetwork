using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Areas.Login.Models
{
    public class DataPostDto
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Topic { get; set; }
        public string VoiceOnline { get; set; }
        public string Date { get; set; }
        public bool Following { get; set; }
        public int Type { get; set; }
        public int? GroupId { get; set; }
        public List<DataPostImageDto> Images { get; set; }

    }

}
