namespace Hadia.Areas.Login.Models
{
    public class DataMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string _thumbNail;

        public string Photo
        {
            get => _thumbNail;
            set => _thumbNail = string.IsNullOrEmpty(value) ? null : "/Profile/Thumbnail/" + value;
        }
        public int? BatchId { get; set; }

        public int? ChapterId { get; set; }


    }

}
