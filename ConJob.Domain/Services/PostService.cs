using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LinqKit;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.Filtering;
using ConJob.Domain.Helper;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Response;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using Microsoft.Extensions.Logging;
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
        private readonly IFilterHelper<PostValidatorDTO> _filterHelper;
        private readonly IFilterHelper<PostDetailsDTO> _filterHelper2; 
        private readonly ILogger<PostService> _logger;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, ILikeRepository likeRepository, IJobRepository jobRepository , IMapper mapper, IFilterHelper<PostValidatorDTO> filterHelper, ILogger<PostService> logger, IFilterHelper<PostDetailsDTO> filterHelper2) 
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _likeRepository = likeRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
            _filterHelper = filterHelper;
            _logger = logger;
            _filterHelper2 = filterHelper2;
        }

        public async Task<ServiceResponse<PostDTO>> SaveAsync(int userId, PostDTO newPost)
        {
            var serviceResponse = new ServiceResponse<PostDTO>();
            try
            {
                var user = await _userRepository.findUserPostAsync(userId);
                newPost.file_url = $"{userId}/{CJConstant.POST_PATH}/{newPost.file_name}";
                var post = _mapper.Map<PostModel>(newPost);
                post = await _postRepository.AddPostAsync(user, post);
                serviceResponse.Data = _mapper.Map<PostDTO>(post);
                serviceResponse.ResponseType = EResponseType.Success;
                serviceResponse.Message = "Add post successfully";
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Owner (User) of post not found.");
            }
            catch 
            {
                throw;
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
                    .FirstOrDefaultAsync(c => c.id == id);
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
                   .FirstOrDefaultAsync(c => c.id == id);
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
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "Post deletion failed. The post has been deleted.";
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
                if (post != null && post.is_actived == false)
                {
                    await _postRepository.ActiveAsync(post.id);
                    serviceResponse.ResponseType = EResponseType.Success;
                    serviceResponse.Message = "Post has been successfully approved.";
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "Post approval failed. The post has been deleted or has been approved.";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException(CJConstant.SOMETHING_WENT_WRONG);
            }
            catch { throw; }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> UndoDeletedAsync(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var post = _postRepository.GetPostById(id);
                if (post != null)
                {
                    if (post.is_deleted == true)
                    {
                        await _postRepository.UndoDeletedAsync(post);
                        serviceResponse.ResponseType = EResponseType.Success;
                        serviceResponse.Message = "Post has been undo delete successfully.";
                    }
                    else
                    {
                        serviceResponse.ResponseType = EResponseType.BadRequest;
                        serviceResponse.Message = "The post has not been deleted.";
                    }
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

        public async Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> GetAllAsync(FilterOptions? filterParameters)
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
                #region apply sorting and paging
                var sortedPosts = _filterHelper2.ApplySorting(posts, filterParameters?.order_by);
                var pagedPosts = await _filterHelper2.ApplyPaging(sortedPosts, filterParameters!.page, filterParameters.limit);
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

        public async Task<ServiceResponse<PagingReturnModel<PostValidatorDTO>>> FilterAllAsync(int user_id, FilterOptions? filter_parameters, DateDTO? date_filter, string? status_filter)
        {
            var role_id = _userRepository.GetRoleByUserId(user_id);
            var predicate = PredicateBuilder.New<PostValidatorDTO>();
            predicate = predicate.Or(p => p.title.Contains(filter_parameters.search_term));
            predicate = predicate.Or(p => p.caption.Contains(filter_parameters.search_term));
            predicate = predicate.Or(p => p.author.Contains(filter_parameters.search_term));

            var serviceResponse = new ServiceResponse<PagingReturnModel<PostValidatorDTO>>();
            try
            {
                var posts = _mapper.ProjectTo<PostValidatorDTO>(_postRepository.GetPosts())
                        .IgnoreQueryFilters().Where(p => (!p.is_deleted) || (p.is_deleted && (p.changed_by == role_id || p.changed_by == 0)))
                        .Where(predicate)
                        .AsNoTracking();
                #region filter status of post
                if (status_filter == CJConstant.IS_DELETED)
                    posts = _mapper.ProjectTo<PostValidatorDTO>(_postRepository.GetSoftDelete())
                        .Where(p => p.changed_by == role_id || p.changed_by == 0)
                        .Where(predicate)
                        .AsNoTracking();
                else if (status_filter == CJConstant.IS_ACTIVED)
                    posts = posts.Where(p => p.is_actived == true);
                else if (status_filter == CJConstant.NOT_YET_APPROVED)
                    posts = posts.Where(p => p.is_deleted == false && p.is_actived == false);
                #endregion
                #region filter create date of post
                if (date_filter?.start_date != null)
                    posts = posts.Where(p => p.created_at >= date_filter.start_date);
                if (date_filter?.end_date != null)
                    posts = posts.Where(p => p.created_at <= date_filter.end_date);
                #endregion
                #region apply sorting and paging
                var sortedPosts = _filterHelper.ApplySorting(posts, filter_parameters!.order_by!);
                var pagedPosts = await _filterHelper.ApplyPaging(sortedPosts, filter_parameters.page, filter_parameters.limit);
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
                else
                {
                    serviceResponse.ResponseType = EResponseType.BadRequest;
                    serviceResponse.Message = "User already like the post.";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException(CJConstant.SOMETHING_WENT_WRONG);
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
        public async Task<ServiceResponse<PagingReturnModel<PostDetailsDTO>>> suggestPost(int userid, FilterJobs filter)
        {
            var serviceResponse = new ServiceResponse<PagingReturnModel<PostDetailsDTO>>();
            var predicate = PredicateBuilder.New<PostDetailsDTO>();
            predicate = predicate.Or(p => p.title.Contains(filter.search_term));
            predicate = predicate.Or(p => p.caption.Contains(filter.search_term));
            predicate = predicate.Or(p => p.author.Contains(filter.search_term));
            predicate = predicate.And(p => p.job!.location.ToLower().Contains(filter.location.ToLower()));
            try
            {
                var user = _userRepository.GetById(userid);
                if (user == null)
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "user not found.";
                    return serviceResponse;
                }
                var Skills = await _userRepository.GetSkillsAsync(userid).Select(e => e.description.ToLower())
                                                  .ToListAsync();
                var posts = await _mapper.ProjectTo<PostDetailsDTO>(_postRepository.GetAllAsync())
                                       .AsNoTracking()
                                       .ToListAsync();
                if (filter.search_term.IsNullOrEmpty() && filter.location.IsNullOrEmpty())
                    posts = posts.OrderByDescending(post => TFIDFhelp.TFIDFScore(post.job!.description.ToLower(), Skills))
                                 .ToList();
                else
                {
                    posts = posts.Where(predicate)
                                 .OrderByDescending(post => TFIDFhelp.TFIDFScore(post.job!.description.ToLower(), Skills))
                                 .ToList();
                }
                var result = await _filterHelper2.ApplyPaging(posts, filter.page, filter.limit);
                if (result != null)
                {
                    serviceResponse.Data = result;
                    serviceResponse.Message = "Get matching posts successfully!";
                }
                else
                {
                    serviceResponse.ResponseType = EResponseType.NotFound;
                    serviceResponse.Message = "Post not found.";
                }
            }
            catch (DbUpdateException ex)
            {
                serviceResponse.ResponseType = EResponseType.NotFound;
                serviceResponse.Message = CJConstant.SOMETHING_WENT_WRONG;
            }
            catch { throw; }
            return serviceResponse;
        }
    }
}
