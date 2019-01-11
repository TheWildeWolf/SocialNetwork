namespace Hadia.Areas.Login.Models
{
    public class DataCommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public string VoiceOnline { get; set; }
        public string ImageOnline { get; set; }
        public int ParentId { get; set; }

        public string date { get; set; }
        public bool read { get; set; }
    }

}
