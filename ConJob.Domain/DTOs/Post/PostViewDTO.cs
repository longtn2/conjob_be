namespace ConJob.Domain.DTOs.Post
{
    public class PostViewDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public int user_id { get; set; }
        public string author { get; set; }
        public string avatar_author { get; set; }
        public string file_url { get; set; }
        public DateTime? created_at { get; set; }
        public int likes { get; set; }
        public FileEnum file_type { get; set; }
    }
}
