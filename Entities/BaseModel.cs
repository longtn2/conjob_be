using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConJob.Entities
{
    public abstract class BaseModel
    {
        [Required]
        public bool is_delete { get; set; } = false;
        public int change_on {  get; set; }
        public DateTime create_on { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
