using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class MessageModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("SenderID")]
        public UserModel Sender_id { get; set; }
        [ForeignKey("ReceiverID")]
        public UserModel Receive_id { get; set; }
    }
}
