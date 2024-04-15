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
    public class FollowRepository : GenericRepository<FollowModel>, IFollowRepository
    {
        public FollowRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<FollowModel> GetFollowbyUser(UserModel fromUser, UserModel toUser)
        {
            return await _context.Follow.Where(e => e.ToUserID == toUser.Id && e.FromUserID == fromUser.Id).FirstOrDefaultAsync();
        }

        public async Task<int> CountFollower(int userid)
        {
            return await _context.Follow.Where(e=> e.ToUser.Id==userid).CountAsync();
        }

    }
}
