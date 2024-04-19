using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.User
{
    public class UserInfoDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public Gender gender { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string? avatar { get; set; }
    }
}
