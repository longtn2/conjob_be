using ConJob.Domain.DTOs.User;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IRocketChatServices
    {
        Task GetListGroup();
        Task<string> CreateAccount(UserRegisterDTO user);
        Task UpdateUserAccount(int userId);
        Task<string> CreateAuthToken(string userId);
    }
}
