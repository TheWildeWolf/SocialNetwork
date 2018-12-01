using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Post_Master
    {
        public int Id { get; set; }
        public string Voice { get; set; }
        public string Topic { get; set; }
        public int OpnedId { get; set; }
        public int GroupId { get; set; }
        public PostStatus Status { get; set; }
        public PostCategory Category { get; set; }
        public DonationType DonationType { get; set; }

        public DateTime CDate { get; set; }
        public DateTime? DDate { get; set; }
        public int? DLogin { get; set; }

        public Mem_Master OpnedBy { get; set; }
        public Post_GroupMaster GroupMaster { get; set; }
        public Mem_Master DeletedBy { get; set; }
        public ICollection<Post_Image> PostImages { get; set; }

        public ICollection<Post_Comment> Comments { get; set; }
    }
    public enum PostStatus : byte
    {
        Active = 1,
        Removed = 2,
        Closed = 3,
        Deleted = 4
    }

    public enum PostCategory : byte
    {
        Discussion = 1,
        Post = 2,
        Album = 3,
        Events = 3,
        Donation = 4,
        CampusFeed = 5,
        Official = 6
    }

    public enum DonationType : byte
    {
        Amount = 1,
        Quantity = 2
    }
}

