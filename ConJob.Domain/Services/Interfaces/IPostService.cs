using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Response;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<IList<PostDTO>>> FilterAllAsync(int pageNo);
        Task<ServiceResponse<PostDTO>> save(int userId, PostDTO newPost);
        Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int userId, int id);
        Task<ServiceResponse<PostDetailsDTO>> UpdateAsync(int userId, int id, PostDTO post);
        Task<ServiceResponse<PostDetailsDTO>> DeleteAsync(int userId, int id);
    }
}
