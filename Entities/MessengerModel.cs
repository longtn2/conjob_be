using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public class MessengerModel :BaseModel
    {
        public int id {  get; set; }
        public string message_content { get; set; }
        public int send_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("send_user_id")]
        public UserModel send_user { get; set; }
        public int receive_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("receive_user_id")]
        public UserModel receive_user { get; set; }

    }
}
