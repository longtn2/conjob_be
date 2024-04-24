using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
namespace ConJob.Domain.Repository.Interfaces
{
    public interface IPostRepository : IGenericRepository<PostModel>
    {
        IQueryable<PostModel> GetUserPosts(int userId);
        IQueryable<PostModel> GetPosts();
        IQueryable<PostModel> GetPostNotDeleted();
        IQueryable<PostModel> GetPostNotApproved();
        Task<PostModel> AddPostAsync(UserModel userpost, PostModel post);
        Task<PostModel> UpdateAsync(int post_id, PostDTO post);
        Task DeleteAsync(int post_id);
        Task ActiveAsync(int post_id);
        int CountLikePost(int post_id);
        Task addJobToPostAsync(int jobId, PostModel post);
    }
}
