using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class DomainModelWork
    {
        
    }

    public class Post_Comment
    {
        public int Id { get; set; }
        //public int PostId { get; set; }
        public int MemberId { get; set; }
        public string Comment { get; set; }
        public CommentStatus Status { get; set; }
        public int PostId { get; set; }
        public CommentType Type { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? RemovedId { get; set; }

        public Post_Master Master { get; set; }
        public Mem_Master DeletedBy { get; set; }
    }

    public enum CommentStatus : byte
    {
        Deleted=1,
        Removed=2
    }

    public enum CommentType:byte
    {
        Voice=1,
        Text=2,
        Image=3
    }
}

