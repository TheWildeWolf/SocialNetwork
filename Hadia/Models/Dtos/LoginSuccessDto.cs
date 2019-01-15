using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.Dtos
{
    public class LoginSuccessDto
    {
        public string Name { get; set; }
        public string UgCollege { get; set; }
        public int Id { get; set; }
        public string ExpireDate { get; set; }
        public string Token { get; set; }
        public int? BatchId { get; set; }
        public int? ChapterId { get; set; }
        private string _thumbNail;

        public string Photo
        {
            get => _thumbNail;
            set => _thumbNail = string.IsNullOrEmpty(value) ? null : "/Profile/Thumbnail/" + value;
        }

    }
}
