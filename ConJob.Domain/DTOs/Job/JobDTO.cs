using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Job
{

    public class JobDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Budget { get; set; }
        public job_typeenum Job_type { get; set; }
        public string Location { get; set; }
        public DateTime Expired_Day { get; set; }
        public int Quanlity { get; set; }
        public string Status { get; set; }
    }
}
