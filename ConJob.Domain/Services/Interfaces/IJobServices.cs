using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IJobServices
    {
        Task<ServiceResponse<IEnumerable<JobDTO>>> GetJobsAsync();
        Task<ServiceResponse<JobDetailsDTO>> GetJobAsync(int id);
        Task<ServiceResponse<JobDTO>> AddJobAsync(int userid, JobDTO job);
        Task<ServiceResponse<JobDTO>> UpdateJobAsync(int userid, int id, JobDTO jobDTO);
        Task<ServiceResponse<JobDTO>> DeleteJobAsync(int id);
        Task<ServiceResponse<PagingReturnModel<JobDTO>>> searchJobAsync(FilterOptions searchJob);
    }
}
