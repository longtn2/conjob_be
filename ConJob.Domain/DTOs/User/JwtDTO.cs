using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.User
{
    public class JwtDTO
    {
        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
        public UserModel users { get; set; }
    }
}
