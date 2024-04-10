using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Authentication
{
    public class RecoverPasswordDTO: PasswordDTO
    {
        public string token { get; set; }   
    }
}
