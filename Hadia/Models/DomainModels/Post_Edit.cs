namespace Hadia.Models.DomainModels
{
    public class Post_Edit
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Topic { get; set; }
        public string Voice { get; set; }

        public Post_Master Post { get; set; }

    }
}

