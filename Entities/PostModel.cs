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
    public class PostModel : BaseModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string caption { get; set; }
        public bool is_deleted { get; set; }
        public bool is_actived {  get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public int user_id { get; set; }    
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel users { get; set; }
        public int job_id { get; set; }
        [JsonIgnore]
        [ForeignKey("job_id")]
        public JobModel jobs { get; set; }
        public virtual ICollection<LikeModel> likes { get; set; }
        public int file_id { get; set; }
        [JsonIgnore]
        [ForeignKey("file_id")]
        public FileModel files { get; set; }

        public virtual ICollection<ReportModel> reports { get; set; }

    }
}
