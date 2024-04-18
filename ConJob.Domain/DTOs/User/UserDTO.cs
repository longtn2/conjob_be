﻿using ConJob.Entities;
using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.User
{
    public class UserDTO
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string? avatar { get; set; }

        public List<RoleModel> roles { get; set; }
    }
}