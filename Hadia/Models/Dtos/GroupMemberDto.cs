using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class GroupMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string _thumbNail;
        public string ProfilePic
        {
            get => _thumbNail;
            set => _thumbNail = string.IsNullOrEmpty(value) ? null : "/Profile/Thumbnail/" + value;
        }
        public bool isAdmin  { get; set; }
    }
}
