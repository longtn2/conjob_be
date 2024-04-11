using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConJob.Domain.Response.EServiceResponseTypes;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ConJob.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public static int PAGE_SIZE { get; set; } = 3;

        public PostService(IPostRepository postRepository, IMapper mapper,  AppDbContext context) 
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<PostDTO>> save(PostDTO newPost)
        {
            var serviceReponse = new ServiceResponse<PostDTO>();
            try
            {
                var toAdd = _mapper.Map<PostModel>(newPost);
                await _postRepository.AddAsync(toAdd);
                serviceReponse.Data = newPost;
                serviceReponse.Message = "Add post successfully";
            } catch (DbUpdateException ex)
            {
                serviceReponse.ResponseType = EResponseType.CannotCreate;
                serviceReponse.Message = "An Error Occur";
            }
            return serviceReponse;
        }

        public async Task<ServiceResponse<IList<PostDTO>>> FilterAllAsync(int pageNo)
        {
            var serviceResponse = new ServiceResponse<IList<PostDTO>>();
            try
            {
                var posts = _context.Post.AsQueryable();

                #region paging
                var result = await PaginatedList<PostModel>.CreateAsync(posts, pageNo, PAGE_SIZE);
                #endregion

                IList<PostDTO> listPost = _mapper.Map<IList<PostDTO>>(result);
                if (listPost != null)
                {
                    serviceResponse.Data = listPost;
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "Post not found.";
                }
            }
            catch { throw; }
            return serviceResponse;
        }
    }
}
