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
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must contain at least 1 character and maximum to 50 character")]
        public string first_name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last Name must contain at least 1 character and maximum to 10 character")] 
        public string last_name { get; set; }
        [Required]
        [RegularExpression("(84|0)[3|5|7|8|9]([0-9]{8})", ErrorMessage = "Phone number is not valid format!")]
        [StringLength(11, MinimumLength = 9)]
        public string phone_number { get; set; }
        public Gender gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string? avatar { get; set; }
    }
}