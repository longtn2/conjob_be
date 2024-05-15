using Amazon.Runtime.Internal.Util;
using AutoMapper;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using ConJob.Entities.Utils.Naming;
using Microsoft.EntityFrameworkCore;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _appliRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IRocketChatServices _rocketChatServices;
        private readonly IMapper _mapper;
        public ApplicantService(IApplicantRepository appliRepository, IUserRepository userRepository, IJobRepository jobRepository,IRocketChatServices rocketChatServices, IMapper mapper)
        {
            _appliRepository = appliRepository;
            _userRepository = userRepository;
            _jobRepository = jobRepository;
            _rocketChatServices = rocketChatServices;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApplicantDTO>> applyJobAsync(int userid, int jobid)
        {
            var serviceResponse = new ServiceResponse<ApplicantDTO>();
            try
            {
                var applicant = _appliRepository.getByJob(userid, jobid);
                if (applicant != null)
                {
                    serviceResponse.ResponseType = EResponseType.CannotCreate;
                    serviceResponse.Message = "applied";
                }
                else
                {
                    applicant = new ApplicantModel()
                    {
                        user = _userRepository.GetById(userid)!,
                        job = _jobRepository.GetById(jobid)!,
                        apply_date = DateTime.UtcNow,
                        status = status_applicants.init,
                    };
                    var job_user = _userRepository.GetById(applicant.job.user_id);
                    var room_name = NameUtils.convertVietnamese($"CJ_{applicant.job.title}_{applicant.user.last_name}x{job_user.last_name}".Replace(" ",""));
                    var room_id = await _rocketChatServices.CreateNewRoom(room_name, new List<string> { applicant.user.rocket_user_id, job_user.rocket_user_id });
                    applicant.rocket_room_id = room_id;
                    await _appliRepository.AddAsync(applicant);
                    serviceResponse.Message = "Successful applied";
                    serviceResponse.ResponseType = EResponseType.Success;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Something wrong" + ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<ApplicantDTO>> rejectJobAsync(int userid, int jobid)
        {
            var serviceResponse = new ServiceResponse<ApplicantDTO>();
            try
            {
                var applicant = _appliRepository.getByJob(userid, jobid)!;
                if (applicant != null)
                {
                    applicant.status = status_applicants.reject;
                    await _appliRepository.UpdateAsync(applicant);
                    serviceResponse.Message = "Reject application";
                    serviceResponse.ResponseType = EResponseType.Success;
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "not found applicants";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<ApplicantDTO>> updateStatusAsync(int userid, int jobid, int status)
        {
            var serviceResponse = new ServiceResponse<ApplicantDTO>();
            try
            {
                var applicant = _appliRepository.getByJob(userid, jobid)!;
                if (applicant != null)
                {
                    applicant.status = (status_applicants)status;
                    await _appliRepository.UpdateAsync(applicant);
                    serviceResponse.Message = "Status application updated";
                    serviceResponse.ResponseType = EResponseType.Success;
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "not found applicants";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<IEnumerable<UserInfoDTO>>> getByJobAsync(int userid, int jobid)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserInfoDTO>>();
            try
            {
                if (_jobRepository.checkOwner(userid, jobid) != null)
                {
                    var applicants = _mapper.ProjectTo<UserInfoDTO>(_appliRepository.FindbyJob(jobid))
                                            .AsNoTracking()
                                            .ToList();
                    if (applicants.Any() == true)
                    {
                        serviceResponse.Data = applicants;
                        serviceResponse.ResponseType = EResponseType.Success;
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.NotFound;
                        serviceResponse.Message = "Applicants not found.";
                    }
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "not owner.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.BadRequest;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<JobDTO>>> getByUserAsync(int userid)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<JobDTO>>();
            try
            {
                var applicants = _mapper.ProjectTo<JobDTO>(_appliRepository.FindbyUser(userid))
                                        .AsNoTracking()
                                        .ToList();
                if (applicants.Any() == true)
                {
                    serviceResponse.Data = applicants;
                    serviceResponse.ResponseType = EResponseType.Success;
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "Applicants not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseType = EResponseType.BadRequest;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            return serviceResponse;
        }

    }
}

