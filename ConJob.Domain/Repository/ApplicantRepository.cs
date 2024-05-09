using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System.Data.Entity;

namespace ConJob.Domain.Repository
{
    public class ApplicantRepository : GenericRepository<ApplicantModel>, IApplicantRepository
    {
        public ApplicantRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public IQueryable<UserModel> FindbyJob(int jobid)
        {
            return _context.applicants.Where(e => e.job.id == jobid).Include(e => e.user).Select(e => e.user);
        }

        public IQueryable<JobModel> FindbyUser(int userid)
        {
            return _context.applicants.Where(e => e.user.id == userid).Include(e => e.job).Select(e => e.job);
        }

        public ApplicantModel getByJob(int userid, int jobid)
        {
            return _context.applicants.Where(e => e.job.id == jobid && e.user.id == userid).FirstOrDefault()!;
        }
    }
}
