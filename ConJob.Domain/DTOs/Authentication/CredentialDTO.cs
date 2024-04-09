
using ConJob.Domain.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Authentication
{
    public class CredentialDTO : UserDTO
    {
        public string Token {  get; set; }
        public string RefreshToken { get; set; }
    }
}
