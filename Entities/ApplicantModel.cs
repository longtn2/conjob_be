using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public string? rocket_room_id { get; set; }
    }
}
