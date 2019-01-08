using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class CommentReplayDto
    {
        public int Id { get; set; }
        public CommentType Type { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
  
    }
}
