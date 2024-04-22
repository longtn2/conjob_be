using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{

    public class RoleModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string role_name { get; set; }
        [JsonIgnore]
        public string role_description { get; set; }
        public virtual ICollection<UserRoleModel> user_roles { get; set; }
    }
}
