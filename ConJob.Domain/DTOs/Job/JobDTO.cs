﻿using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConJob.Domain.DTOs.Post;

namespace ConJob.Domain.DTOs.Job
{

    public class JobDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double budget { get; set; }
        public job_typeenum job_type { get; set; }
        public string create_by { get; set; }
        public string avatar { get; set; } = "";
        public string location { get; set; }
        public DateTime expired_day { get; set; }
        public int quanlity { get; set; }
        public int status { get; set; }
        public virtual ICollection<PostDTO>? posts { get; set; }
    }
}
