using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Repository.Interface;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConJob.Entities;
namespace ConJob.Domain.Repository.Interfaces
{
    public interface IPostRepository : IGenericRepository<PostModel>
    {
        Task<PostModel> AddPostAsync(PostModel post);
        Task<PostModel> UpdateAsync(int post_id, PostDTO post);
    }
}
