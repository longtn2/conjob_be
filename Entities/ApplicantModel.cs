using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public enum status_applicants
    {
        reject = -2,
        cancel = -1,
        init = 1,
        accepted = 2,
        pending = 3,
        successed = 4,

    }
    public class ApplicantModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel user { get; set; }
        public int job_id { get; set; }
        [JsonIgnore]
        [ForeignKey("job_id")]
        public JobModel job { get; set; }
        public DateTime apply_date { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public status_applicants status { get; set; }
        public string? rocket_room_id { get; set; }
    }
}
