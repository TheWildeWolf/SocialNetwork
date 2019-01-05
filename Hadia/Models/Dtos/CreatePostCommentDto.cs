using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class CreatePostCommentDto
    {
        [Required]
        public int MasterId { get; set; }
        [Required]
        public string Comment { get; set; }

        public CommentType Type { get; set; }
    }
}
