using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;


namespace ConJob.Domain.DTOs.Apllicant
{
    public class ApplicantDTO
    {
        public UserInfoDTO user { get; set; }
        public JobDTO job { get; set; }
        public DateTime apply_date { get; set; }
    }
}
