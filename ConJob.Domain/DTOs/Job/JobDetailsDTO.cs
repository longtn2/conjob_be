using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.User;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Job
{
    public class JobDetailsDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        public job_typeenum job_type { get; set; }
        public string location { get; set; }
        public DateTime expired_day { get; set; }
        public int quanlity { get; set; }
        public string status { get; set; }
        public int category_id { get; set; }
    }
}
