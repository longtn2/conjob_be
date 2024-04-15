using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Follow
{
    public class FollowDTO
    {
        public int FromUserID {  get; set; }

        public int ToUserID { get; set; }
    }
}
