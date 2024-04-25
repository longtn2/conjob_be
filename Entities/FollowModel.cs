using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public class FollowModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int from_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("from_user_id")]
        public UserModel from_user_follow { get; set; }
        public int to_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("to_user_id")]
        public UserModel to_user_follow { get; set; }

    }
}
