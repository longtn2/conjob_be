using AutoMapper;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _appliRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        public ApplicantService(IApplicantRepository appliRepository, IUserRepository userRepository, IJobRepository jobRepository, IMapper mapper)
        {
            _appliRepository = appliRepository;
            _userRepository = userRepository;
            _jobRepository = jobRepository;
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
    }
}

