using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IApplicantRepository : IGenericRepository<ApplicantModel>
    {
        IQueryable<UserModel> FindbyJob(int jobId);
        ApplicantModel getByJob(int userid, int jobid);
        IQueryable<JobModel> FindbyUser(int userid);
    }
}
