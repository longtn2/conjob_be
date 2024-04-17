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

        public  FollowModel GetFollowbyUser(UserModel fromUser, UserModel toUser)
        {
            return  _context.Follows.Where(e => e.to_user_follow.id == toUser.id && e.from_user_follow.id == fromUser.id).FirstOrDefault()!;
        }

        public async Task<int> CountFollower(int userid)
        {
            return await _context.Follows.Where(e => e.to_user_follow.id == userid).CountAsync();
        }

    }
}
