using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConJob.Data;
using ConJob.Entities;
using ConJob.Domain.DTOs.Job;
using AutoMapper;

namespace ConJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobModelsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public JobModelsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/JobModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobModel>>> GetJob()
        {
            return await _context.jobs.ToListAsync();
        }

        // GET: api/JobModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobModel>> GetJobModel(int id)
        {
            var jobModel = await _context.jobs.FindAsync(id);

            if (jobModel == null)
            {
                return NotFound();
            }

            return jobModel;
        }

        // PUT: api/JobModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobModel(int id, JobModel jobModel)
        {
            if (id != jobModel.id)
            {
                return BadRequest();
            }

            _context.Entry(jobModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobModel>> PostJobModel(JobDTO jobDTO)
        {
            var jobModel = _mapper.Map<JobModel>(jobDTO);
            _context.jobs.Add(jobModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobModel", new { id = jobModel.id }, jobModel);
        }

        // DELETE: api/JobModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobModel(int id)
        {
            var jobModel = await _context.jobs.FindAsync(id);
            if (jobModel == null)
            {
                return NotFound();
            }

            _context.jobs.Remove(jobModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobModelExists(int id)
        {
            return _context.jobs.Any(e => e.id == id);
        }
    }
}
