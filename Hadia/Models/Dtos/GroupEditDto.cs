using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class GroupEditDto
    {
        public int GroupId { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
