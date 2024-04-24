using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Role;
using ConJob.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConJob.Domain.DTOs.User
{
    public class UserDetailsDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Gender gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string phone_number { get; set; }

        [Column(TypeName = "text")]
        public string? avatar { get; set; }
        public ICollection<RolesDTO> roles { get; set; }
        public ICollection<PostDetailsDTO> posts { get; set; }
        public ICollection<JobDetailsDTO> jobs { get; set; }
        public ICollection<Personal_skillModel> skills { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
    }
}
