using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Hangfire.Common;
using LinqKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;
using static ConJob.Domain.Services.Interfaces.IJobServices;
using static ConJob.Domain.Services.JobSevices;

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

        private IQueryable<JobModel> GetJobs()
        {
            return _context.Jobs;
        }
        public async Task<ServiceResponse<JobDetailsDTO>> AddJobAsync(int userid, JobDetailsDTO job)
        {
            var serviceReponse = new ServiceResponse<JobDetailsDTO>();
            try
            {
                var user = _userRepository.GetById(userid);
                if (user != null)
                {
                    var toAddjob = _mapper.Map<JobModel>(job);
                    toAddjob.category = _context.Categories.Where(c => c.id == job.category_id).First();
                    toAddjob.user = user;
                    await _jobRepository.AddAsync(toAddjob);
                    serviceReponse.ResponseType = EResponseType.Success;
                    serviceReponse.Data = _mapper.Map<JobDetailsDTO>(toAddjob);
                }
                else
                {
                    serviceReponse.ResponseType = EResponseType.NotFound;
                    serviceReponse.Message = "not found user";
                }
            }
            catch (DbException ex)
            {
                serviceReponse.ResponseType = EResponseType.CannotCreate;
                serviceReponse.Message = ex.Message;
            }
            return serviceReponse;
        }

        public async Task<ServiceResponse<JobDTO>> DeleteJobAsync(int id)
        {

            var serviceReponse = new ServiceResponse<JobDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                if (job != null)
                {
                    var toAddjob = _mapper.Map<JobModel>(job);
                    serviceReponse.ResponseType = EResponseType.Success;
                    serviceReponse.Data = _mapper.Map<JobDTO>(toAddjob);
                    await _jobRepository.SoftDelete(job);
                }
                else
                {
                    serviceReponse.ResponseType = EResponseType.NotFound;
                }
            }
            catch (DbException ex)
            {
                serviceReponse.ResponseType = EResponseType.CannotCreate;
                serviceReponse.Message = ex.Message;
            }
            return serviceReponse;
        }

        public async Task<ServiceResponse<JobDTO>> GetJobAsync(int id)
        {
            var serviceReponse = new ServiceResponse<JobDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                if (job == null)
                {
                    serviceReponse.ResponseType = EResponseType.NotFound;
                }
                else
                {
                    serviceReponse.ResponseType = EResponseType.Success;
                    serviceReponse.Data = _mapper.Map<JobDTO>(job);
                }
            }
            catch (DbException ex)
            {
                serviceReponse.ResponseType = EResponseType.CannotCreate;
                serviceReponse.Message = ex.Message;
            }
            return serviceReponse;
        }

        public async Task<ServiceResponse<IEnumerable<JobDTO>>> GetJobsAsync()
        {
            var serviceReponse = new ServiceResponse<IEnumerable<JobDTO>>();
            try
            {
                var job = _jobRepository.GetAll();
                serviceReponse.ResponseType = EResponseType.Success;
                serviceReponse.Data = _mapper.Map<IEnumerable<JobDTO>>(job);

            }
            catch (DbException ex)
            {
                serviceReponse.ResponseType = EResponseType.BadRequest;
                serviceReponse.Message = ex.Message;
            }
            return serviceReponse;
        }

        public async Task<ServiceResponse<PagingReturnModel<JobDTO>>> searchJobAsync(FilterOptions searchJob)
        {
            var predicate = PredicateBuilder.New<JobDTO>();
            var searchJob2 = new SearchJob();
            predicate = predicate.Or(p => p.title.Contains(searchJob2.search));
            var serviceResponse = new ServiceResponse<PagingReturnModel<JobDTO>>();

            try
            {
                var job = _mapper.ProjectTo<JobDTO>(GetJobs()).Where(predicate).AsNoTracking();
                var sortedJob=_filterHelper.ApplySorting(job,searchJob.OrderBy);
                var pagedJob = await _filterHelper.ApplyPaging(sortedJob, searchJob.Page, searchJob.Limit);
                if (job.Any()==true)
                {
                    serviceResponse.Data =pagedJob ;
                }
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<JobDTO>> UpdateJobAsync(int id, JobDTO jobDTO)
        {
            var serviceReponse = new ServiceResponse<JobDTO>();
            try
            {
                var job = _jobRepository.GetById(id);
                var toAddjob = _mapper.Map(jobDTO, job);
                if (toAddjob != null)
                {
                    await _jobRepository.UpdateAsync(toAddjob!);
                    serviceReponse.ResponseType = EResponseType.Success;
                    serviceReponse.Data = _mapper.Map<JobDTO>(toAddjob);
                }
                else
                {
                    serviceReponse.ResponseType = EResponseType.BadRequest;
                    serviceReponse.Message = "Something wrong";
                }
            }
            catch (DbException ex)
            {
                serviceReponse.ResponseType = EResponseType.CannotCreate;
                serviceReponse.Message = ex.Message;
            }

            return serviceReponse;
        }
    }
}
