using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
namespace ConJob.Domain.Repository.Interfaces
{
    public interface IPostRepository : IGenericRepository<PostModel>
    {
        IQueryable<PostModel> GetUserPosts(int userId);
        IQueryable<PostModel> GetPosts();
        PostModel GetPostById(int id);
        Task<PostModel> AddPostAsync(UserModel userpost, PostModel post);
        Task UpdateAsync(int userId, PostModel postModel, PostDTO postDTO);
        Task DeleteAsync(int post_id);
        Task ActiveAsync(int post_id);
        int CountLikePost(int post_id);
        Task addJobToPostAsync(int jobId, PostModel post);
        Task UndoDeletedAsync(PostModel post);
    }
}
