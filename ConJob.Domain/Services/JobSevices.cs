using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using LinqKit;
using System.Data.Common;
using System.Data.Entity;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class JobSevices : IJobServices
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;
        private readonly IFilterHelper<JobDTO> _filterHelper;
        public JobSevices(IMapper mapper, IJobRepository jobRepository, IUserRepository userRepository, AppDbContext context, IFilterHelper<JobDTO> filterHelper)
        {
            _mapper = mapper;
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _context = context;
            _filterHelper = filterHelper;
        }

        public async Task<ServiceResponse<JobDetailsDTO>> AddJobAsync(int userid, JobDetailsDTO job)
        {
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            try
            {
                var user = _userRepository.GetById(userid);
                if (user != null)
                {
                    var toAddjob = _mapper.Map<JobModel>(job);
                    toAddjob.user = user;
                    toAddjob.posts = null!;
                    await _jobRepository.AddAsync(toAddjob);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Data = _mapper.Map<JobDetailsDTO>(toAddjob);
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "not found user";
                }
            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<JobDTO>> DeleteJobAsync(int id)
        {

            var serviceResponse = new ServiceResponse<JobDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                if (job != null)
                {
                    var toAddjob = _mapper.Map<JobModel>(job);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Data = _mapper.Map<JobDTO>(toAddjob);
                    await _jobRepository.SoftDelete(job);
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                }
            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<JobDetailsDTO>> GetJobAsync(int id)
        {
            var serviceResponse = new ServiceResponse<JobDetailsDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                if (job == null)
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Data = _mapper.Map<JobDetailsDTO>(job);
                }
            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<JobDTO>>> GetJobsAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<JobDTO>>();
            try
            {
                var job = _jobRepository.GetAllAsync();
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Data = _mapper.ProjectTo<JobDTO>(job);
            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.BadRequest;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PagingReturnModel<JobDTO>>> searchJobAsync(FilterOptions searchJob)
        {
            var predicate = PredicateBuilder.New<JobDTO>();
            predicate = predicate.Or(p => p.title.Contains(searchJob.SearchTerm));
            var serviceResponse = new ServiceResponse<PagingReturnModel<JobDTO>>();

            try
            {
                var job = _mapper.ProjectTo<JobDTO>(_jobRepository.GetAllAsync())
                    .Where(predicate)
                    .AsNoTracking();
                var sortedJob = _filterHelper.ApplySorting(job, searchJob.OrderBy);
                var pagedJob = await _filterHelper.ApplyPaging(sortedJob, searchJob.Page, searchJob.Limit);
                if (job.Any() == true)
                {
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Data = pagedJob;
                }
            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.BadRequest;
                serviceResponse.Message = "Somthing wrong" + ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<JobDTO>> UpdateJobAsync(int userid, int id, JobDTO jobDTO)
        {
            var serviceResponse = new ServiceResponse<JobDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                var toAddjob = _mapper.Map(jobDTO, job);
                toAddjob!.posts = null!;
                if (_jobRepository.checkOwner(userid, id) != null)
                {
                    if (toAddjob != null)
                    {
                        await _jobRepository.UpdateAsync(toAddjob!);
                        serviceResponse.ResponseType = EResponseType.Success;
                        serviceResponse.Data = _mapper.Map<JobDTO>(toAddjob);
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.BadRequest;
                        serviceResponse.Message = "Something wrong";
                    }
                }
                else
                {
                    serviceResponse.ResponseType= EResponseType.BadRequest;
                    serviceResponse.Message = "User is not own";
                }

            }
            catch (DbException ex)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}
