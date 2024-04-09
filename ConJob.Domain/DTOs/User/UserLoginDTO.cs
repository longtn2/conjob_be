using ConJob.Domain.DTOs.Authentication;
using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.User
{
    public class UserLoginDTO : PasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}
