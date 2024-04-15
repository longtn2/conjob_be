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
        public interface IJobRepository
        {
            Task<IEnumerable<Job>> GetJobsAsync();
            Task<Job> GetJobAsync(int id);
            Task<Job> AddJobAsync(Job job);
            Task UpdateJobAsync(Job job);
            Task DeleteJobAsync(int id);
        }
    }
}
