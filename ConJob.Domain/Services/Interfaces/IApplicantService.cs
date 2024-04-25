using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IApplicantService
    {
        Task<ServiceResponse<ApplicantDTO>> applyJobAsync(int userid, int jobid);
        Task<ServiceResponse<ApplicantDTO>> rejectJobAsync(int userid, int jobid);
        Task<ServiceResponse<ApplicantDTO>> updateStatusAsync(int userid, int jobid, int status);
       Task<ServiceResponse<IEnumerable<UserInfoDTO>>> getByJobAsync(int userid,int jobid);
        Task<ServiceResponse<IEnumerable<JobDTO>>> getByUserAsync(int jobid);
    }
}
