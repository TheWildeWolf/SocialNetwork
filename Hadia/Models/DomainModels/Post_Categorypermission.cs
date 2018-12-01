using System;

namespace Hadia.Models.DomainModels
{
    public class Post_Categorypermission
    {
        public int Id { get; set; }
        public int PostCategoryId { get; set; }
        public int MemberId { get; set; }
        public bool IsPermitted { get; set; }
        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }

        public int CLogin { get; set; }
        public int? MLogin { get; set; }

        public Mem_Master CreatedBy { get; set; }
        public Mem_Master ModifiedBy { get; set; }

        public Mem_Master Member { get; set; }

        public Post_Category Category { get; set; }

    }

}

