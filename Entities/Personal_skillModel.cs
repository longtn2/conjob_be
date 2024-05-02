using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public class Personal_skillModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string exp { get; set; }
        public int user_id { get; set; }
        public string desciption { get; set; }
        [JsonIgnore]
        [ForeignKey("user_id")]
        public UserModel user { get; set; }
        public int skill_id { get; set; }
        [JsonIgnore]
        [ForeignKey("skill_id")]
        public SkillModel skill { get; set; }
    }
}
