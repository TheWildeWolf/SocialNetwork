using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class CreatePostDto
    {
        [Required]
        public string Topic { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<string> Images { get; set; }
        public string Voice { get; set; }
    }


}
