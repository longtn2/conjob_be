using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using ConJob.Domain.DTOs.Post;
using System.Data.Entity;
namespace ConJob.Domain.Repository
{
    public class PostRepository : GenericRepository<PostModel>, IPostRepository
    {
        public PostRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<PostModel> AddPostAsync(UserModel userpost, PostModel post)
        {
            if (userpost.posts == null)
                userpost.posts = new List<PostModel>();
            userpost.posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<PostModel> UpdateAsync(int id, PostDTO postDTO)
        {
            var post = _context.Posts.FirstOrDefault(p => p.id == id);
            if (post != null)
            {
                post = _mapper.Map(postDTO, post);
                await _context.SaveChangesAsync();
            }
            return post;
        }

        public async Task DeleteAsync(int post_id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.id == post_id);
            if (post != null)
            {
                post.is_deleted = !post.is_deleted;
                if (post.is_actived == true)
                {
                    post.is_actived = false;
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActiveAsync(int post_id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.id == post_id);
            if (post != null)
            {
                post.is_actived = !post.is_actived;
                if (post.is_deleted == true)
                {
                    post.is_deleted = false;
                }
                await _context.SaveChangesAsync();
            }
        }

        public int CountLikePost(int post_id)
        {
            return _context.Likes.Where(p => p.post_id == post_id).Count();
        }

        public IQueryable<PostModel> GetUserPosts(int userId)
        {
            return _context.Posts
                .Where(c => c.user.id == userId);
        }

        public IQueryable<PostModel> GetPosts()
        {
            return _context.Posts;
        }

        public IQueryable<PostModel> GetPostNotDeleted()
        {
            var posts = _context.Posts.AsQueryable();
            posts = _context.Posts.Where(p => p.is_deleted == false);
            return posts;
        }

        public IQueryable<PostModel> GetPostNotApproved()
        {
            var posts = _context.Posts.AsQueryable();
            posts = _context.Posts.Where(p => p.is_deleted == false).Where(p => p.is_actived == false);
            return posts;
        }

        public async Task addJobToPostAsync(int jobId, PostModel post)
        {
            post.job_id = jobId;
            await _context.SaveChangesAsync();
        }

    }
}
