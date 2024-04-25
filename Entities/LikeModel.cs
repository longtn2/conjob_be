using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public class LikeModel: BaseModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel user { get; set; }
        public int post_id { get; set; }
        [JsonIgnore]
        [ForeignKey("post_id")]
        public PostModel post{ get; set; }

    }
}
