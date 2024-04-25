using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Apllicant
{
    public class ApplicantDetailsDTO
    {
        public int id { get; set; }
        public UserInfoDTO user { get; set; }
        public JobDTO job { get; set; }
        public DateTime apply_date { get; set; }
        public string status { get; set; }
    }
}
