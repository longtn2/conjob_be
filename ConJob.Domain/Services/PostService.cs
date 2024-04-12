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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public static int PAGE_SIZE { get; set; } = 3;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, IMapper mapper,  AppDbContext context) 
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        private IQueryable<PostModel> GetUserPosts(int userId)
        {
            return _context.Post
                .Where(c => c.User.Id == userId);
        }

        public async Task<ServiceResponse<PostDTO>> save(int userId, PostDTO newPost)
        {
            var serviceResponse = new ServiceResponse<PostDTO>();
            try
            {
                var user = await _userRepository.findUserPostAsync(userId);
                var post = _mapper.Map<PostModel>(newPost);
                if (user.Posts == null)
                    user.Posts = new List<PostModel>();
                user.Posts.Add(post);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<PostDTO>(post);
                serviceResponse.Message = "Add post successfully";
            } catch (InvalidOperationException)
            {
                serviceResponse.ResponseType = EResponseType.CannotCreate;
                serviceResponse.Message = "Owner (User) of post not found.";
            }
            return serviceResponse;
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

        public async Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int userId, int id)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                serviceResponse.Data = await _mapper.ProjectTo<PostDetailsDTO>(GetUserPosts(userId))
                    .AsNoTracking()
                    .FirstAsync(c => c.Id == id);
            }
            catch (InvalidOperationException)
            {
                serviceResponse.ResponseType = EResponseType.NotFound;
                serviceResponse.Message = "Post and/or Owner (User) not found.";
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostDetailsDTO>> UpdateAsync(int userId, int id, PostDTO postDTO)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                var post = await GetUserPosts(userId)
                    .FirstAsync(c => c.Id == id);
                if (post != null)
                {
                    post = await _postRepository.UpdateAsync(id, postDTO);
                    serviceResponse.Data = _mapper.Map<PostDetailsDTO>(post);
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "You doesn't permission to edit this field.";
                }
            }
            catch (InvalidOperationException)
            {
                serviceResponse.ResponseType = EResponseType.NotFound;
                serviceResponse.Message = "Post and/or Owner (User) not found.";
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostDetailsDTO>> DeleteAsync(int userId, int id)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                var post = await GetUserPosts(userId)
                    .FirstAsync(c => c.Id == id);
                await _postRepository.RemoveAsync(post);
            }
            catch (DbUpdateConcurrencyException)
            {
                serviceResponse.ResponseType = EResponseType.NotFound;
            }
            catch { throw; }
            return serviceResponse;
        }
    }
}
