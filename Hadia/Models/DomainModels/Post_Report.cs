namespace Hadia.Models.DomainModels
{
    public class Post_Report
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int ReportedId { get; set; }
        public int ReasonId { get; set; }
        public string Narration { get; set; }

        public Post_Master PostMaster { get; set; }
        public Mem_Master ReportedBy { get; set; }
        public Post_ReportReason ReportReason { get; set; }
    }
}

