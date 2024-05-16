using AutoMapper;
using ConJob.Data;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;

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
            post.file.url = $"{userpost.id}/{CJConstant.POST_PATH}/{post.file.name}";
            userpost.posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task UpdateAsync(int userId, PostModel postModel, PostDTO postDTO)
        {
            var file = postModel.file;
            _mapper.Map(postDTO, postModel);
            if (postDTO.file_type == null || postDTO.file_name == null)
            {
                postModel.file = file;
            }
            else
            {
                postModel.file.url = $"{userId}/{CJConstant.POST_PATH}/{postDTO.file_name}";
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int post_id)
        {
            var post = _context.posts.Where(p => p.is_deleted == false).FirstOrDefault(p => p.id == post_id);
            if (post != null)
            {
                post.is_deleted = true;
                post.is_actived = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActiveAsync(int post_id)
        {
            var post = _context.posts.Where(p => p.is_deleted == false && p.is_actived == false).FirstOrDefault(p => p.id == post_id);
            if (post != null)
            {
                post.is_actived = true;
                await _context.SaveChangesAsync();
            }
        }

        public int CountLikePost(int post_id)
        {
            return _context.likes.Where(p => p.post_id == post_id).Count();
        }

        public IQueryable<PostModel> GetUserPosts(int userId)
        {
            return _context.posts.Where(p => p.is_deleted == false)
                .Where(c => c.user.id == userId);
        }

        public IQueryable<PostModel> GetPosts()
        {
            return _context.posts.Where(p => p.is_deleted == false);
        }

        public async Task addJobToPostAsync(int jobId, PostModel post)
        {
            post.job_id = jobId;
            await _context.SaveChangesAsync();
        }

        public PostModel GetPostById(int id)
        {
            return _context.posts.IgnoreQueryFilters().Where(p => p.id == id).FirstOrDefault();
        }

        public async Task UndoDeletedAsync(PostModel post)
        {
            post.is_deleted = false;
            await _context.SaveChangesAsync();
        }

    }
}
