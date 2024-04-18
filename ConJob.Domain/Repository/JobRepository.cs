using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class JobRepository : GenericRepository<JobModel>, IJobRepository
    {
        public JobRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<JobModel> searchJobs(SearchJob searchJob)
        {
            return _context.Jobs.Where(e => e.title.Contains(searchJob.search) && e.location.Contains(searchJob.location))
                                .Include(e => e.posts)
                                .Skip((searchJob.page - 1) * searchJob.pageSize)
                                .Take(searchJob.pageSize);
        }
    }
}
