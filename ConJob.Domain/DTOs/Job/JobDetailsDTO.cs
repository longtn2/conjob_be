using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Post;
using ConJob.Entities;

namespace ConJob.Domain.DTOs.Job
{
    public class JobDetailsDTO
    {
        public int id {  get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        public job_typeenum job_type { get; set; }
        public string create_by { get; set; }
        public string avatar { get; set; } = "";
        public string location { get; set; }
        public DateTime expired_day { get; set; }
        public int quantity { get; set; }
        public int status { get; set; }
        public virtual ICollection<PostDTO> posts { get; set; }
        public virtual ICollection<ApplicantDTO> applicants { get; set; }
    }
}
