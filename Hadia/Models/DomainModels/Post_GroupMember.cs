﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Post_GroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MemberId { get; set; }

        public bool IsGroupAdmin { get; set; }
        public bool IsActive { get; set; }

        public DateTime CDate { get; set; }
        public int AddedBy { get; set; }

        public DateTime MDate { get; set; }
        public int? ModifiedBy { get; set; }

        public Mem_Master AddedMember { get; set; }
        public Mem_Master ModifiedMember { get; set; }

        public Mem_Master Member { get; set; }

        public Post_GroupMaster GroupMaster { get; set; }
        
    }
}
