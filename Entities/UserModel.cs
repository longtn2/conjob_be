using ConJob.Entities.Utils.Variable;
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
        public int id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must contain at least 1 character and maximum to 50 character")]
        public string first_name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Last Name must contain at least 1 character and maximum to 10 character")]
        public string last_name { get; set; }
        [Required]
        [RegularExpression(RegexUtils.EMAIL, ErrorMessage = "Email format is not Valid!")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email length must between 5 and 70 character")]
        public string email { get; set; }
        [JsonIgnore]
        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must contain atleast 8 character")]
        public string password { get; set; }
        [JsonIgnore]
        [Required]
        public bool is_email_confirmed { get; set; } = false;
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly dob { get; set; }
        [Required]
        public string address { get; set; }
        public string? fcm_token { get; set; }
        [Required]
        [RegularExpression(RegexUtils.PHONE_NUMBER, ErrorMessage = "Phone number is not valid format!")]
        [StringLength(11, MinimumLength = 9)]
        public string phone_number { get; set; }
        [Column(TypeName = "text")]
        public string? avatar { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRoleModel> user_roles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Personal_skillModel> personal_skills { get; set; }
        [JsonIgnore]
        public virtual ICollection<JWTModel> jwts { get; set; }
        [JsonIgnore]
        public virtual ICollection<PostModel> posts { get; set; }
        [JsonIgnore]
        public virtual ICollection<ApplicantModel> applicants { get; set; }
        [JsonIgnore]
        public virtual ICollection<JobModel> jobs { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReportModel> reports { get; set; }
        [JsonIgnore]
        public virtual ICollection<LikeModel> likes { get; set; }
        [JsonIgnore]
        public virtual ICollection<FollowModel> followers { get; set; }
        [JsonIgnore]
        public virtual ICollection<FollowModel> following { get; set; }
        [JsonIgnore]
        public virtual ICollection<NotificationModel> from_user_notifications { get; set; }
        [JsonIgnore]
        public virtual ICollection<MessengerModel> send_users { get; set; }
        [JsonIgnore]
        public virtual ICollection<MessengerModel> receive_users { get; set; }
    }
}
