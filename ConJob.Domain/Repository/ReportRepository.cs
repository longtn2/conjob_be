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
using Microsoft.EntityFrameworkCore;

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
