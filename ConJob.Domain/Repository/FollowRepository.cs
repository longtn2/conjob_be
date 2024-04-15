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
            return await _context.Follows.Where(e => e.to_user_follows.id == toUser.id && e.from_user_follows.id == fromUser.id).FirstOrDefaultAsync();
        }

        public async Task<int> CountFollower(int userid)
        {
            return await _context.Follows.Where(e => e.to_user_follows.id == userid).CountAsync();
        }

    }
}
