using ConJob.Domain.DTOs.Report;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IReportServices
    {
        Task<ServiceResponse<ReportByUserDTO>> reportPost(ReportDTO reportDTO);
    }
}
