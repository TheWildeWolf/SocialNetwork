using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Http;

namespace Hadia.Models.Dtos
{
    public class CreatePostDto
    {
        [Required]
        public string Topic { get; set; }
        public int OpenedId { get; set; }
        public DonationType? DonationType { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<IFormFile> PostImages { get; set; }
        public IFormFile Voice { get; set; }
    }


}
