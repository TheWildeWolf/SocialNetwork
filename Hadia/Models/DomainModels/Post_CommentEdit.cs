namespace Hadia.Models.DomainModels
{
    public class Post_CommentEdit
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Comment { get; set; }

        public Post_Comment PostComment { get; set; }
    }
}

