using AutoMapper;
using ConJob.Data;
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
    public class ReportRepository : GenericRepository<ReportModel>, IReportRepository
    {
        public ReportRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ReportModel> GetReport(UserModel user, PostModel post)
        {
            return await _context.Report.Where(e=> e.User.Id==user.Id && e.Post.Id==post.Id).FirstOrDefaultAsync();
        }
    }
}
