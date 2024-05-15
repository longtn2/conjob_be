using ConJob.Domain.DTOs.User;
using ConJob.Entities;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IRocketChatServices
    {
        Task GetListGroup();
        Task<string> CreateAccount(UserModel user);
        Task<string> CreateNewRoom(string RoomName, List<string> Users);
        Task ObtainCredentialToken(UserModel user);
    }
}
