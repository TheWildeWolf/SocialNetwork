using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class GroupResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public bool IsAdmin { get; set; }
        private string _image;
        public string Image
        {
            get => _image;
            set => _image = string.IsNullOrEmpty(value) ? null : "/GroupImage/" + value;
        }
    }
}
