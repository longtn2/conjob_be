using AutoMapper;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static ConJob.Domain.Response.EServiceResponseTypes;

namespace ConJob.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly IFilterHelper<PostDetailsDTO> _filterHelper;
        private readonly IFilterHelper<PostDTO> _filterHelper2;

        public static int PAGE_SIZE { get; set; } = 1;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ILikeRepository likeRepository, IJobRepository jobRepository , IMapper mapper, IFilterHelper<PostDetailsDTO> filterHelper, IFilterHelper<PostDTO> filterHelper2) 
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _likeRepository = likeRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _filterHelper = filterHelper;
            _filterHelper2 = filterHelper2;
        }

        public async Task<ServiceResponse<PostDTO>> SaveAsync(int userId, PostDTO newPost)
        {
            var serviceResponse = new ServiceResponse<PostDTO>();
            try
            {
                var user = await _userRepository.findUserPostAsync(userId);
                var post = _mapper.Map<PostModel>(newPost);
                post = await _postRepository.AddPostAsync(user, post);
                serviceResponse.Data = _mapper.Map<PostDTO>(post);
                serviceResponse.Message = "Add post successfully";
            } catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Owner (User) of post not found.");
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PagingReturnModel<PostDTO>>> GetAllAsync(int pageNo)
        {
            var serviceResponse = new ServiceResponse<PagingReturnModel<PostDTO>>();
            try
            {
                var posts = _mapper.ProjectTo<PostDTO>(_postRepository.GetPostNotDeleted())
                        .AsNoTracking();
                #region paging
                var result = await _filterHelper2.ApplyPaging(posts, pageNo, PAGE_SIZE);
                #endregion
                serviceResponse.Data = result;
                serviceResponse.Message = "Get all posts successfully!";
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post and/or Owner (User) not found.");
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int userId, int id)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                serviceResponse.Data = await _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetUserPosts(userId))
                    .AsNoTracking()
                    .FirstAsync(c => c.id == id);
                serviceResponse.Message = "Get post by id successfully!";
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post and/or Owner (User) not found.");
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                serviceResponse.Data = await _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetPosts())
                    .AsNoTracking()
                    .FirstAsync(c => c.id == id);
                serviceResponse.Message = "Get post by id successfully!";
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
                var post = await _postRepository.GetUserPosts(userId)
                    .FirstAsync(c => c.id == id);
                if (post != null)
                {
                    post = await _postRepository.UpdateAsync(id, postDTO);
                    serviceResponse.Data = _mapper.Map<PostDetailsDTO>(post);
                    serviceResponse.Message = "Update post successfully!";
                }
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post and / or Owner(User) not found.");
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> DeleteAsync(int userId, int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var post = await _postRepository.GetUserPosts(userId)
                    .FirstAsync(c => c.id == id);
                if (post != null)
                {
                    post = _postRepository.GetById(id);
                    await _postRepository.DeleteAsync(post.id);
                    serviceResponse.Message = "Delete post successfully!";
                }
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post and / or Owner(User) not found.");
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> DeleteAsync(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var post = _postRepository.GetById(id);
                if (post != null)
                {
                    await _postRepository.DeleteAsync(post.id);
                    serviceResponse.Message = "Delete post successfully!";
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "Post not found";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> ActiveAsync(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var post = _postRepository.GetById(id);
                await _postRepository.ActiveAsync(post.id);
                serviceResponse.Message = "Post has been successfully approved.";
            }
            catch (DbUpdateConcurrencyException)
            {
                serviceResponse.ResponseType = EResponseType.NotFound;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> FilterAllAsync(FilterOptions filterParameters, string statusFilter)
        {
            var predicate = PredicateBuilder.New<PostDetailsDTO>();
            predicate = predicate.Or(p => p.title.Contains(filterParameters.SearchTerm));
            predicate = predicate.Or(p => p.caption.Contains(filterParameters.SearchTerm));
            predicate = predicate.Or(p => p.author.Contains(filterParameters.SearchTerm));

            var serviceResponse = new ServiceResponse<PagingReturnModel<PostDetailsDTO>>();
            try
            {
                var posts = _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetPosts())
                        .Where(predicate)
                        .AsNoTracking();
                if (statusFilter == "is_deleted")
                    posts = posts.Where(p => p.is_deleted == true);
                else if (statusFilter == "is_actived")
                    posts = posts.Where(p => p.is_actived == true);
                else
                    posts = posts.Where(p => p.is_deleted == false && p.is_actived == false);
                // apply sorting and paging
                var sortedPosts = _filterHelper.ApplySorting(posts, filterParameters.OrderBy);
                var pagedPosts = await _filterHelper.ApplyPaging(sortedPosts, filterParameters.Page, filterParameters.Limit);

                serviceResponse.Data = pagedPosts;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> UserLikePost(int userId, int postId)
        {
            var serviceResponse = new ServiceResponse<int>();
            var toCheck = _likeRepository.getLikeByUserPost(userId, postId);
            if (toCheck == null)
            {
                await _likeRepository.AddAsync(new LikeModel { 
                                        user = _userRepository.GetById(userId), 
                                        post = _postRepository.GetById(postId) });
                serviceResponse.Message = "Like post successfully";
            }
            else
            {
                serviceResponse.Message = "User already like the post.";
            }
            serviceResponse.Data = _postRepository.CountLikePost(postId);
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> AddJobToPost(int userId, int jobId, int postId)
        {
            var serviceResponse = new ServiceResponse<object>(); 
            try
            {
                var post = await _postRepository.GetUserPosts(userId)
                            .FirstOrDefaultAsync(c => c.id == postId);
                var job = await _jobRepository.GetUserJobs(userId)
                            .FirstOrDefaultAsync(c => c.id == jobId);
                if (job != null && post != null)
                {
                    var toCheck = _postRepository.GetById(postId);
                    if (toCheck.job_id == null)
                    {
                        await _postRepository.addJobToPostAsync(jobId, toCheck);
                        serviceResponse.Message = "Add job to post successfully.";
                    }
                    else
                    {
                        throw new DbUpdateException(serviceResponse.Message = "Post already exist job.");
                    }
                }
                else
                {
                    throw new DbUpdateException("Post and/or Job and/or Owner (User) not found.");
                }
            }
            catch (InvalidOperationException)
            {
                throw new BadHttpRequestException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch { throw; }
            return serviceResponse;
        }
    }
}
