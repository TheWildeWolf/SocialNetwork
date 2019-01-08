using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class MemberPhotoDto
    {
        public int Id { get; set; }

        private string _image;

        public string Image
        {
            get => _image;
            set => _image = "/Profile/"+value;
        }

    }
}
