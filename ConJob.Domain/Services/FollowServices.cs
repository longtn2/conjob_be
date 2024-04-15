using AutoMapper;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class FollowServices : IFollowServices
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public FollowServices(IFollowRepository followRepository, IUserRepository userRepository,IMapper mapper)
        {
            _followRepository = followRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<FollowDTO>> followUser(FollowDTO follow)
        {
            var serviceResponse = new ServiceResponse<FollowDTO>();
            try
            {
                var toAdd= _mapper.Map<FollowModel>(follow);
                await _followRepository.AddAsync(toAdd);
                serviceResponse.Data=_mapper.Map<FollowDTO>(toAdd);
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Somthing wrong.";
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FollowDTO>> unfollowUser(FollowDTO follow)
        {
            throw new NotImplementedException();
        }
    }
}
