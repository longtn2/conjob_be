using ConJob.Data.Migrations;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Response;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IJobServices
    {
        Task<ServiceResponse<IEnumerable<JobDTO>>> searchJobAsync(SearchJob searchJob);
        Task<ServiceResponse<IEnumerable<JobDTO>>> GetJobsAsync();
        Task<ServiceResponse<JobDetailsDTO>> GetJobAsync(int id);
        Task<ServiceResponse<JobDetailsDTO>> AddJobAsync(int userid,JobDetailsDTO job);
        Task<ServiceResponse<JobDTO>> UpdateJobAsync(int id, JobDTO jobDTO);
        Task<ServiceResponse<JobDTO>> DeleteJobAsync(int id);

    }
}
