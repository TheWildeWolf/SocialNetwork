using System.Collections.Generic;

namespace Hadia.Areas.Login.Models
{
    public class DataMainDto
    {
        public List<DataPostDto> posts { get; set; }
        public List<DataPostImageDto> postImages { get; set; }
        public List<DataMemberDto> members { get; set; }
        public List<DataCommentDto> comments { get; set; }
        public List<DataLikeDto> likes { get; set; }
    }

}
