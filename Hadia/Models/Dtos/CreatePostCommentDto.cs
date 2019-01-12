using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Http;

namespace Hadia.Models.Dtos
{
    public class CreatePostCommentDto
    {
        [Required]
        public int MasterId { get; set; }
        public string Comment { get; set; }

        public CommentType Type { get; set; }

        public IFormFile File { get; set; }
    }
}
