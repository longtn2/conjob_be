using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Rocketchat
{
    public class CreateTokenDTO
    {
        public string userId { get; set; }
        public string authToken { get; set; }
    }
}
