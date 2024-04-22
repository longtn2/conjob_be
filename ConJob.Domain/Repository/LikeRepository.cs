using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;

namespace ConJob.Domain.Repository
{
    public class LikeRepository : GenericRepository<LikeModel>, ILikeRepository
    {
        public LikeRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public LikeModel getLikeByUserPost(int userId, int postId)
        {
            return _context.likes.Where(l => l.user_id == userId && l.post_id == postId).SingleOrDefault();
        }
    }
}
