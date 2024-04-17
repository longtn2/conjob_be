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
    public class LikeRepository : GenericRepository<LikeModel>, ILikeRepository
    {
        public LikeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public LikeModel getLikeByUserPost(int userId, int postId)
        {
            return _context.Likes.Where(l => l.user_id == userId && l.post_id == postId).SingleOrDefault();
        }
    }
}
