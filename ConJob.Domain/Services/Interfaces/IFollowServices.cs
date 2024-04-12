using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IFollowServices
    {
        Task<ServiceResponse<FollowDTO>> followUser (FollowDTO follow);
        Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow);
    }
}
