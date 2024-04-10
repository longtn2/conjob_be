using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class FollowModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("FromUser")]
        public int FromUserID { get; set; }
        [ForeignKey("ToUser")]
        public int ToUserID { get; set; }

        public virtual UserModel FromUser { get; set; } = null!;

        public virtual UserModel ToUser { get; set; } = null!;

    }
}
