using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Job
{
    public class SearchJob
    {
        public string search { get; set; } = "";
        public string location { get; set; } = "";
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
