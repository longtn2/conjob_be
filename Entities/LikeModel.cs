using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities
{
    public class LikeModel: BaseModel
    {
        public int Id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }
        public UserModel User { get; set; }

    }
}
