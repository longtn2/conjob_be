using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository.Interfaces
{
    public interface IFollowRepository: IGenericRepository<FollowModel>
    {
        Task<FollowModel> GetFollowbyUser(UserModel fromUser, UserModel toUser);
        Task<int> CountFollower(int userid);
    }
}
