using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<PagingReturnModel<PostDTO>>> GetAllAsync(int pageNo);
        Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> FilterAllAsync(FilterOptions filterParameters, string statusFilter);
        Task<ServiceResponse<PostDTO>> SaveAsync(int userId, PostDTO newPost);
        Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int userId, int id);
        Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int id);
        Task<ServiceResponse<PostDetailsDTO>> UpdateAsync(int userId, int id, PostDTO post);
        Task<ServiceResponse<object>> DeleteAsync(int userId, int id);
        Task<ServiceResponse<object>> DeleteAsync(int id);
        Task<ServiceResponse<object>> ActiveAsync(int id);
        Task<ServiceResponse<int>> UserLikePost(int userId, int postId);
        Task<ServiceResponse<object>> AddJobToPost(int userId, int jobId, int postId);
    }
}
