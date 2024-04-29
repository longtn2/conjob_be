﻿using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Entities;

namespace ConJob.Domain.DTOs.Apllicant
{
    public class ApplicantDetailsDTO
    {
        public int id { get; set; }
        public UserInfoDTO user { get; set; }
        public JobDTO job { get; set; }
        public DateTime apply_date { get; set; }
        public status_applicants status { get; set; }
    }
}
