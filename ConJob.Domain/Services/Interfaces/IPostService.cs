using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> GetAllAsync(FilterOptions? filter_parameters);
        Task<ServiceResponse<PagingReturnModel<PostValidatorDTO>>> FilterAllAsync(int user_id, FilterOptions? filter_parameters, DateDTO? date_filter, string? status_filter);
        Task<ServiceResponse<PostDTO>> SaveAsync(int userId, PostDTO newPost);
        Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int id);
        Task<ServiceResponse<PostDetailsDTO>> UpdateAsync(int userId, int id, PostDTO post);
        Task<ServiceResponse<object>> DeleteAsync(int userId, int id);
        Task<ServiceResponse<object>> DeleteAsync(int id);
        Task<ServiceResponse<object>> ActiveAsync(int id);
        Task<ServiceResponse<object>> UndoDeletedAsync(int id);
        Task<ServiceResponse<int>> UserLikePost(int userId, int postId);
        Task<ServiceResponse<object>> AddJobToPost(int userId, int jobId, int postId);
        Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> suggestPost(int userid, FilterJobs filter);
        Task<ServiceResponse<object>> DeleteAsync(List<int> ids);
        Task<ServiceResponse<object>> ActiveAsync(List<int> ids);
    }
}
