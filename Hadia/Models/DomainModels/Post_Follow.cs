namespace Hadia.Models.DomainModels
{
    public class Post_Follow
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int MemberId { get; set; }
        public bool Follow { get; set; }

        public Mem_Master Member { get; set; }
        public Post_Master Post { get; set; }
    }
}

