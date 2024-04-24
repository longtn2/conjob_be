using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IJobRepository:IGenericRepository<JobModel>
    {
        IQueryable<JobModel> searchJob(string search, string location);
        JobModel checkOwner(int userid, int jobid);
    }
}
