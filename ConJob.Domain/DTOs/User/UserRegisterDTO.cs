using ConJob.Domain.DTOs.Authentication;
using ConJob.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Domain.DTOs.User
{
    public class UserRegisterDTO : PasswordDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must contain at least 1 character and maximum to 50 character")]
        public string first_name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last Name must contain at least 1 character and maximum to 10 character")]
        public string last_name { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email format is not Valid!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email length must between 5 and 70 character")]
        public string email { get; set; }

        [Required]
        [RegularExpression("(84|0)[3|5|7|8|9]([0-9]{8})", ErrorMessage = "Phone number is not valid format!")]
        [StringLength(11, MinimumLength = 9)]
        public string phone_number { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        [Required]
        public string address { get; set; }

        [Column(TypeName = "text")]
        public string? avatar { get; set; }
    }
}