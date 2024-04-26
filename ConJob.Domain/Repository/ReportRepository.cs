using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;

namespace ConJob.Domain.Repository
{
    public class ReportRepository : GenericRepository<ReportModel>, IReportRepository
    {
        public ReportRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public ReportModel GetReport(int user_id, int post_id)
        {
            return _context.reports.Where(e => e.user.id == user_id && e.post.id == post_id).FirstOrDefault()!;
        }
    }
}
