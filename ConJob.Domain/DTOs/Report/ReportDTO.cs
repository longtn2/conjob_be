using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Report
{
    public class ReportDTO
    {
        public string reason { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
    }
}
