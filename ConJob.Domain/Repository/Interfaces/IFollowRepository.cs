using ConJob.Domain.Repository.Interface;
using ConJob.Entities;


namespace ConJob.Domain.Repository.Interfaces
{
    public interface IFollowRepository : IGenericRepository<FollowModel>
    {
        FollowModel GetFollowbyUser(UserModel fromUser, UserModel toUser);
        Task<int> CountFollower(int userid);
        Task<int> CountFolling(int userid);
    }
}
