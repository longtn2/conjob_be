using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Authentication
{
    public class TokenDTO
    {
        [Required]
        public string token { get; set; }   
    }
}
