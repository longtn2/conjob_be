using Amazon.S3.Model;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository.Interface;
using ConJob.Domain.Response;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<ServiceResponse<IList<PostDTO>>> FilterAllAsync(int pageNo);
        Task<ServiceResponse<PostDTO>> save(PostDTO newPost);
    }
}
