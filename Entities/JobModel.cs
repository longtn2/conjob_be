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
    public enum job_typeenum
    {
        remote,
        fulltime,
        parttime,
        onsite,
        hybrid,
        freelance
    };
    public class JobModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Budget { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public job_typeenum Job_type { get; set; }
        public string Location { get; set; }
        public DateTime Expired_Day { get; set; }
        public int Quanlity { get; set; }
        public string Status { get; set; }
        public ICollection<ApplicantModel> Applicants { get; set; }
        public CategoryModel Category { get; set; }
        public UserModel User { get; set; }
    }
}
