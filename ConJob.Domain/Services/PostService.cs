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

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ILikeRepository likeRepository, IJobRepository jobRepository , IMapper mapper, IFilterHelper<PostDetailsDTO> filterHelper) 
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _likeRepository = likeRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _filterHelper = filterHelper;
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
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Message = "Add post successfully";
            } catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Owner (User) of post not found.");
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<PostDetailsDTO>> FindByIdAsync(int id)
        {
            var serviceResponse = new ServiceResponse<PostDetailsDTO>();
            try
            {
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Data = await _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetPosts())
                    .AsNoTracking()
                    .FirstAsync(c => c.id == id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Post and / or Owner(User) not found.");
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
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Update post successfully!";
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
                    serviceResponse.ResponseType = EResponseType.Success;
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

        public async Task<ServiceResponse<object>> DeleteAsync(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var post = _postRepository.GetById(id);
                if (post != null)
                {
                    await _postRepository.DeleteAsync(post.id);
                    serviceResponse.ResponseType = EResponseType.Success;
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
                if (post != null)
                {
                    await _postRepository.ActiveAsync(post.id);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Post has been successfully approved.";
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

        public async Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> FilterAllAsync(FilterOptions? filterParameters, DateDTO? dateFilter, string? status_filter)
        {
            var predicate = PredicateBuilder.New<PostDetailsDTO>();
            predicate = predicate.Or(p => p.title.Contains(filterParameters.search_term));
            predicate = predicate.Or(p => p.caption.Contains(filterParameters.search_term));
            predicate = predicate.Or(p => p.author.Contains(filterParameters.search_term));

            var serviceResponse = new ServiceResponse<PagingReturnModel<PostDetailsDTO>>();
            try
            {
                var posts = _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetPosts())
                        .Where(predicate)
                        .AsNoTracking();
                #region filter status of post
                if (status_filter == "is_deleted")
                    posts = _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetSoftDelete())
                        .Where(predicate)
                        .AsNoTracking();
                else if (status_filter == "is_actived")
                    posts = posts.Where(p => p.is_actived == true);
                else
                    posts = posts.Where(p => p.is_deleted == false && p.is_actived == false);
                #endregion
                #region filter create date of post
                if (dateFilter.start_date != null)
                    posts = posts.Where(p => p.created_at >= dateFilter.start_date);
                if (dateFilter.end_date != null)
                    posts = posts.Where(p => p.created_at <= dateFilter.end_date);
                #endregion
                #region apply sorting and paging
                var sortedPosts = _filterHelper.ApplySorting(posts, filterParameters.order_by);
                var pagedPosts = await _filterHelper.ApplyPaging(sortedPosts, filterParameters.page, filterParameters.limit);
                #endregion
                serviceResponse.ResponseType = EResponseType.Success;
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
            try
            {
                var toCheck = _likeRepository.getLikeByUserPost(userId, postId);
                if (toCheck == null)
                {
                    await _likeRepository.AddAsync(new LikeModel
                    {
                        user = _userRepository.GetById(userId),
                        post = _postRepository.GetById(postId)
                    });
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Like post successfully";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("User already like the post.");
            }
            catch { throw; }
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
                        serviceResponse.ResponseType = EResponseType.Success;
                        serviceResponse.Message = "Add job to post successfully.";
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.CannotUpdate;
                        serviceResponse.Message = "Post already exist job.";
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
