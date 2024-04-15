using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class ReportModel: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [RegularExpression("\"([a-zA-Z0-9_]+)\"\n\n(.*[^\n])\n")]
        public string Reason { get; set; }
        public PostModel Post { get; set; }
        public UserModel User { get; set; }
    }
}
