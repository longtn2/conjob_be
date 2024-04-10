using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{

    public enum Gender
    {
        male,
        female,
        other
    }
    public class UserModel: BaseModel
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
   
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must contain at least 1 character and maximum to 50 character")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last Name must contain at least 1 character and maximum to 10 character")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email format is not Valid!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email length must between 5 and 70 character")]
        public string Email { get; set; }

        [JsonIgnore]
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must contain atleast 8 character")]
        public string Password { get; set; }

        [JsonIgnore]
        [Required]
        public bool IsEmailConfirmed { get; set; } = false;

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB {  get; set; }
        [Required]
        public string Address {  get; set; }

        public string? FCMToken {  get; set; }

        [Required]
        [RegularExpression("([84|0])([3|5|7|8|9])+([0-9]{8})", ErrorMessage = "Phone number is not valid format!")]
        [StringLength(11, MinimumLength = 9)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "text")]
        public string? Avatar { get; set; }


        [JsonIgnore, Required]
        public bool isDeleted { get; set; } = false;

        [JsonIgnore]
        public virtual ICollection<UserRoleModel> UserRoles { get; set; }
        [JsonIgnore]
        public virtual ICollection<JWTModel> Jwts { get; set; }

    }
}
