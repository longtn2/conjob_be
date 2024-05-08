using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Rocketchat
{
    public class TeamCreateDTO
    {
        public string _id {  get; set; }
        public string name { get; set; }
        public string roomId { get; set; }
    }
}
