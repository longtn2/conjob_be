using ConJob.Domain.Repository.Interface;
using ConJob.Entities;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IApplicantRepository : IGenericRepository<ApplicantModel>
    {
        IQueryable<UserModel> FindbyJob(int jobId);
        ApplicantModel getByJob(int userid, int jobid);
        IQueryable<JobModel> FindbyUser(int userid);
    }
}
