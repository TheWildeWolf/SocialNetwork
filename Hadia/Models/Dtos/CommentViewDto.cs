using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class CommentViewDto
    {
        public int Id { get; set; }
        public CommentType Type { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string ProfilePhoto { get; set; }
        public string Ago { get; set; }
        public List<CommentViewDto> Replies { get; set; }
    }
}
