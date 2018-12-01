using System;

namespace Hadia.Models.DomainModels
{
    public class Post_Image
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Image { get; set; }

        public DateTime CDate { get; set; }
        public bool isDeleted { get; set; }

        public DateTime? DDate { get; set; }
        public int? DLogin { get; set; }

        public Mem_Master DeletedBy { get; set; }
        public Post_Master PostMaster { get; set; }
    }


}

