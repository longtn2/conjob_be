using ConJob.Entities;
using ConJob.Domain.DTOs.Post;
using ConJob.Entities.Validation;

namespace ConJob.Domain.DTOs.Job
{

    public class JobDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        public job_typeenum job_type { get; set; }
        public string location { get; set; }
        [DateInTheFuture]
        public DateTime expired_day { get; set; }
        public int quanlity { get; set; }
        public DateTime? created_at { get; set; }
        public virtual ICollection<PostDTO>? posts { get; set; }
    }
}
