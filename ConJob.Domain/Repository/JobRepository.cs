using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System.Data.Entity;

namespace ConJob.Domain.Repository
{
    public class JobRepository : GenericRepository<JobModel>, IJobRepository
    {
        public JobRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IQueryable<JobModel> GetUserJobs(int userId)
        {
            return _context.Jobs
                .Where(c => c.user.id == userId);
        }

        public IQueryable<JobModel> searchJob(string search, string location)
        {
            return _context.Jobs.Where(e => e.title.Contains(search) && e.location.Contains(location))
                     .Include(e => e.posts);
        }
    }
}
