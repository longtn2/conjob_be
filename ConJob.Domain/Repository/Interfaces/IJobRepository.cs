using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
namespace ConJob.Domain.Repository.Interfaces
{
    public interface IJobRepository:IGenericRepository<JobModel>
    {
        IQueryable<JobModel> searchJob(string search, string location);
        IQueryable<JobModel> GetUserJobs(int userId);
        JobModel checkOwner(int userid, int jobid);
    }
}
