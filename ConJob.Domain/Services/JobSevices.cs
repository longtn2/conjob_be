using AutoMapper;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.Repository;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Hangfire.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Services.Interfaces.IJobServices;
using static ConJob.Domain.Services.JobSevices;

namespace ConJob.Domain.Services
{
    public class JobSevices: IJobServices
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        public JobSevices(DbContext context, IMapper mapper, IJobRepository jobRepository)
        {
            _context = context;
            _mapper = mapper;
            _jobRepository = jobRepository;
        }
        public void ConfigureServices(IServiceCollection services)
            {
                services.AddAutoMapper(typeof(StartupBase));
            }

        public async Task<IEnumerable<JobDTO>> GetJobsAsync()
            {
                var jobs = await _jobRepository.GetJobsAsync();
                var jobDTOs = _mapper.Map<IEnumerable<JobDTO>>(jobs);
                return jobDTOs;
            }

        public async Task<JobDTO> GetJobAsync(int id)
            {

                var job = await _jobRepository.GetJobAsync(id);
                if (job == null)
                {
                    return null;
                }
                var jobDTO = _mapper.Map<JobDTO>(job);
                return jobDTO;
            }

        public async Task<JobDTO> AddJobAsync(JobDTO jobDTO)
            {
                // Convert JobDTO to a Job entity (if using Entity Framework)

                var job = _mapper.Map<Job>(jobDTO);

            // Add the job to the repository or database

            var addedJob = await _jobRepository.AddJobAsync(job); // Add job to repo (if applicable)

                // Convert the added job back to JobDTO
                var addedJobDTO = _mapper.Map<JobDTO>(addedJob);

            return addedJobDTO;
            }

        public async Task<JobDTO> UpdateJobAsync(int id, JobDTO jobDTO)
            {
                var job = await _jobRepository.GetJobAsync(id);

                if (job == null)
                {
                return null;
                }

                _mapper.Map(jobDTO, job);
                await _jobRepository.UpdateJobAsync(job);

                var updatedJobDTO = _mapper.Map<JobDTO>(job);

                return updatedJobDTO;
            }

            public async Task DeleteJobAsync(int id)
            {
                var job = await _jobRepository.GetJobAsync(id); 

                if (job == null)
                {
                    return; 
                }
                await _jobRepository.DeleteJobAsync(id); 
            }
        }
}
