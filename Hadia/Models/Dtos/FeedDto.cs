using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class FeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePic { get; set; }
        public string Date { get; set; }
        public string Topic { get; set; }
        public int Type { get; set; }
        public List<string> Images { get; set; }
        public string Voice { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
