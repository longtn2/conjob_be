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
        public UserModel users { get; set; }
        public int skill_id { get; set; }
        [JsonIgnore]
        [ForeignKey("skill_id")]
        public SkillModel skills { get; set; }
    }
}
