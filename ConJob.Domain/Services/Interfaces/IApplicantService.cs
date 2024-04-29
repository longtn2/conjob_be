using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<ServiceResponse<ApplicantDTO>> applyJobAsync(int userid, int jobid);
        Task<ServiceResponse<ApplicantDTO>> rejectJobAsync(int userid, int jobid);
        Task<ServiceResponse<ApplicantDTO>> updateStatusAsync(int userid, int jobid, int status);
    }
}
