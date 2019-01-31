using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class CreateGroupDto
    {
        public string GroupName { get; set; }
        public GroupPrivacy OpenOrClosed { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public List<int> Members { get; set; }
    }

}
