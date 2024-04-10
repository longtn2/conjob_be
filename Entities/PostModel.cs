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
        public enum ReactionEnum
        {
            like,
            heart,
            sad,
            slime,
            angry
        };
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Caption { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ReactionEnum Reaction { get; set; }
        public UserModel User { get; set; }
        public FileModel File { get; set; }
        public ICollection<ReportModel> Reports { get; set; }
        public ICollection<CommentModel> Comments { get; set; }

    }
}
