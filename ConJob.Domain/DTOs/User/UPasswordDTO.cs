using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.User
{
    public class UPasswordDTO
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
