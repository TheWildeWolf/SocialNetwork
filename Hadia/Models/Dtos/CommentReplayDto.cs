using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class CommentReplayDto
    {
        public CommentType Type { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string VoiceUrl { get; set; }
    }
}
