using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public class ApplicantModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int user_id {  get; set; }   
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel user { get; set; }
        public int job_id { get; set; }
        [JsonIgnore]
        [ForeignKey("job_id")]
        public JobModel job { get; set; }
        public DateTime apply_date { get; set; }
        public string status { get; set; }
    }
}
