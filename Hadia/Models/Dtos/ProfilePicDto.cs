using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hadia.Models.Dtos
{
    public class ProfilePicDto
    {
        public IFormFile Image { get; set; }
    }
}
