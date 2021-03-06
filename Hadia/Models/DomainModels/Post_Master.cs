﻿using System;
using System.Collections.Generic;

namespace Hadia.Models.DomainModels
{
    public class Post_Master
    {
        public int Id { get; set; }
        public string Voice { get; set; }
        public string Topic { get; set; }
        public int OpnedId { get; set; }
        public int? GroupId { get; set; }
        public PostStatus Status { get; set; }
        public int CategoryId { get; set; }
        public DonationType DonationType { get; set; }

        public DateTime CDate { get; set; }
        public DateTime? DDate { get; set; }
        public int? DLogin { get; set; }

        public Post_Category Category { get; set; }
        public Mem_Master OpendBy { get; set; }
        public Post_GroupMaster GroupMaster { get; set; }
        public Mem_Master DeletedBy { get; set; }
        public ICollection<Post_Image> PostImages { get; set; }

        public ICollection<Post_Comment> Comments { get; set; }
        public ICollection<Post_Like> Likes { get; set; }

        public ICollection<Post_Report> Reports { get; set; }
        public ICollection<Post_Edit> EditedPosts { get; set; }
        public ICollection<Post_View> PostViews { get; set; }
        public ICollection<Post_Follow> Followers { get; set; }
        public ICollection<Post_Donation> Donations { get; set; }
        public ICollection<Post_EventRegistration> EventRegistrations { get; set; }
    }
    public enum PostStatus : byte
    {
        Active = 1,
        Removed = 2,
        Closed = 3,
        Deleted = 4
    }


    public enum DonationType : byte
    {
        None = 0,
        Amount = 1,
        Quantity = 2
    }
}

