using System;

namespace Hadia.Models.DomainModels
{
    public class Post_Donation
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        public int MemberId { get; set; }

        public decimal AmountOrQuantity { get; set; }

        public DateTime CDate { get; set; }

        public Post_Master Post { get; set; }
        public Mem_Master Member { get; set; }

        
    }
}

