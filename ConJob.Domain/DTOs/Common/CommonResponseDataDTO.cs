using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Common
{
    public class CommonResponseDataDTO <T>
    {
        public T data { get; set; } 
        public int status_code { get; set; }
    }
}
