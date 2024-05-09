using ConJob.Entities;

namespace ConJob.Domain.DTOs.Post
{
    public class PostValidatorDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string author { get; set; }
        public FileEnum type_file { get; set; }
        public string name_file { get; set; }
        public string url_file { get; set; }
        public DateTime? created_at { get; set; }
        public int? changed_by { get; set; }
        public bool is_deleted { get; set; }
        public bool is_actived { get; set; }
        public string? job_title { get; set; }
        public job_typeenum? job_type { get; set; }
    }
}
