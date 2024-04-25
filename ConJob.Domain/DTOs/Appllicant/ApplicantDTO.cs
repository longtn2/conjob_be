using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Apllicant
{
    public class ApplicantDTO
    {
        public UserInfoDTO user { get; set; }
        public JobDTO job { get; set; }
        public DateTime apply_date { get; set; }
    }
}
