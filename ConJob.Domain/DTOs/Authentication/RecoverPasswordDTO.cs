using System.ComponentModel.DataAnnotations;

namespace ConJob.Domain.DTOs.Authentication
{
    public class RecoverPasswordDTO : PasswordDTO
    {
        [Required]
        public string token { get; set; }
    }
}