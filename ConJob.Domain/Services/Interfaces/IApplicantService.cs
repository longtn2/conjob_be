using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<ServiceResponse<ApplicantDTO>> applyJobAsync(int userid, int jobid);
        Task<ServiceResponse<IEnumerable<UserInfoDTO>>> getByJobAsync(int userid, int jobid);
        Task<ServiceResponse<IEnumerable<JobDTO>>> getByUserAsync(int jobid);
    }
}
