using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class ApplicantModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ResumeModel Resume { get; set; }
        public UserModel User{ get; set; }
        public JobModel Job { get; set; }
        public DateTime Apply_date { get; set; }
        public string Status { get; set; }
    }
}
