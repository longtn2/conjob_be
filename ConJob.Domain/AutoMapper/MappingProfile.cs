using AutoMapper;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Entities;
namespace ConJob.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        private readonly IPasswordHasher _pwdHasher;
        public MappingProfile(IPasswordHasher pwdHasher)
        {
            _pwdHasher = pwdHasher;
            CreateMap<SkillDTO, SkillModel>().ReverseMap();
            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest=>dest.password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList())); 
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.token_hash_value, opt => opt.MapFrom(src => _pwdHasher.md5(src.Token)));
            CreateMap<UserInfoDTO, UserModel>();
            CreateMap<UserModel, UserInfoDTO>().ReverseMap();
            CreateMap<UserModel, UserDetailsDTO>()
                .ForMember(dest => dest.dob, opt => opt.MapFrom(src => src.dob))
                .ForMember(dest => dest.posts, opt => opt.MapFrom(src => src.posts))
                .ForMember(dest => dest.jobs, opt => opt.MapFrom(src => src.jobs))
                .ForMember(dest => dest.skills, opt => opt.MapFrom(src => src.personal_skills))
                .ForMember(dest => dest.followers, opt => opt.MapFrom(src => src.followers.Select(l => l.to_user_id).Count()))
                .ForMember(dest => dest.following, opt => opt.MapFrom(src => src.following.Select(l => l.from_user_id).Count()))
                .ForMember(dest => dest.roles, opt => opt.MapFrom(src => src.user_roles.Select(y => y.role).ToList()));
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();
            CreateMap<FollowModel, FollowDTO>()
               .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_follow.id))
               .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.from_user_follow.id)).ReverseMap();
            CreateMap<FollowModel, FollowDTO>()
                .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_id))
                .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.to_user_id)).ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
            CreateMap<JobModel, JobDTO>().ForMember(dto => dto.posts, opt => opt.MapFrom(x => x.posts)).ReverseMap();
            CreateMap<JobModel, JobDetailsDTO>().ReverseMap();
            CreateMap<PostModel, PostDTO>().ForMember(dto => dto.name_file, opt => opt.MapFrom(x => x.file.name))
                                           .ForMember(dto => dto.type_file, opt => opt.MapFrom(x => x.file.type))
                                           .ForMember(dto => dto.url_file, opt => opt.MapFrom(x => x.file.url))
                                           .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.user.last_name)).ReverseMap();
            CreateMap<PostModel, PostDetailsDTO>()
                                            .ForMember(dto => dto.name_file, opt => opt.MapFrom(x => x.file.name))
                                            .ForMember(dto => dto.type_file, opt => opt.MapFrom(x => x.file.type))
                                            .ForMember(dto => dto.url_file, opt => opt.MapFrom(x => x.file.url))
                                            .ForMember(dto => dto.avatar_author, opt => opt.MapFrom(x => x.user.avatar))
                                            .ForMember(dto => dto.likes, opt => opt.MapFrom(x => x.likes.Select(l => l.post_id).Count()))
                                            .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.user.last_name)).ReverseMap();
            CreateMap<ReportModel, ReportDTO>()
                 .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.post.id))
                 .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.user.id))
                 .ReverseMap();
            CreateMap<ReportModel, ReportByUserDTO>()
              .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.post.id))
              .ReverseMap();
        }
    }
}
