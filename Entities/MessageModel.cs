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
    public class MessageModel :BaseModel
    {
        public int id {  get; set; }
        public string content { get; set; }
        public int send_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("send_user_id")]
        public UserModel send_users { get; set; }
        public int receive_user_id { get; set; }
        [JsonIgnore]
        [ForeignKey("receive_user_id")]
        public UserModel receive_users { get; set; }

    }
}
