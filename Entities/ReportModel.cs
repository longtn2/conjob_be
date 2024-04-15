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
    public class ReportModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string reason { get; set; }
        [JsonIgnore]
        [ForeignKey("post_id")]
        public PostModel posts { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel users { get; set; }
    }
}
