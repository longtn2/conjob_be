using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Repository
{
    public class PostRepository : GenericRepository<PostModel>, IPostRepository
    {
        public PostRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<PostModel> AddPostAsync(PostModel post)
        {
            var file = new FileModel()
            {
                Name = post.File.Name,
                Type = post.File.Type,
            };
            await _context.File.AddAsync(file);
            _context.SaveChanges();
            post.File = file;
            await _context.Post.AddAsync(post);
            _context.SaveChanges();
            return post;
        }

        public async Task<PostModel> UpdateAsync(int id, PostDTO postDTO)
        {
            var post = _context.Post.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post = _mapper.Map(postDTO, post);
                await _context.SaveChangesAsync();
            }
            return post;
        }
    }
}
