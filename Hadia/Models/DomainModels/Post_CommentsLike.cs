using System;

namespace Hadia.Models.DomainModels
{
    public class Post_CommentsLike
    {
        public int Id { get; set; }

        public int CommentId { get; set; }
        public int MemberId { get; set; }

        public bool Like { get; set; }
        public DateTime CDate { get; set; }

        public Post_Comment Comment { get; set; }
        public Mem_Master Member { get; set; }
    }
}

