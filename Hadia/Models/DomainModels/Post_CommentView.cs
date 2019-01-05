using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_CommentView
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int MemberId { get; set; }
        public bool IsRead { get; set; }

        public DateTime CDate { get; set; }
        public Post_Comment Comment { get; set; }
        public Mem_Master Member { get; set; }
    }
}
