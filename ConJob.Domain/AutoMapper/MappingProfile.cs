using AutoMapper;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Apllicant;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Job;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using ConJob.Domain.Helper;
namespace ConJob.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        private readonly IPasswordHasher _pwdHasher;
        private readonly IS3Services _s3Services;
        public MappingProfile(IPasswordHasher pwdHasher, IS3Services s3Services)
        {
            _pwdHasher = pwdHasher;
            _s3Services = s3Services;
            CreateMap<SkillDTO, SkillModel>().ReverseMap();
            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest => dest.password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList()))
                 .ForMember(dto => dto.avatar, opt => opt.MapFrom(x => s3Services.PresignedGet(x.avatar).Data.url));
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
                .ForMember(dest => dest.roles, opt => opt.MapFrom(src => src.user_roles.Select(y => y.role).ToList()))
                .ForMember(dto => dto.avatar, opt => opt.MapFrom(x => s3Services.PresignedGet(x.avatar).Data.url));
            CreateMap<UserModel, CredentialDTO>()
                .ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList()))
                .ForMember(dto => dto.avatar, opt => opt.MapFrom(x => s3Services.PresignedGet(x.avatar).Data.url));
            CreateMap<RoleModel, RolesDTO>().ReverseMap();
            CreateMap<FollowModel, FollowDTO>()
               .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_follow.id))
               .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.from_user_follow.id)).ReverseMap();
            CreateMap<FollowModel, FollowDTO>()
                .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_id))
                .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.to_user_id)).ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
            CreateMap<JobModel, JobDTO>().ForMember(dto => dto.posts, opt => opt.MapFrom(x => x.posts))
                                         .ForMember(dto => dto.create_by, opt => opt.MapFrom(x => x.user.last_name))
                                         .ForMember(dto => dto.avatar, opt => opt.MapFrom(x => s3Services.PresignedGet(x.user.avatar).Data.url))
                                         .ReverseMap();
            CreateMap<JobModel, JobDetailsDTO>().ForMember(dto => dto.posts, opt => opt.MapFrom(x=> x.posts))
                                                .ReverseMap();
            CreateMap<JobModel, JobMatchDTO>().ForMember(dto => dto.user_id, opt => opt.MapFrom(x => x.user.id));
            CreateMap<PostModel, PostDTO>().ForMember(dto => dto.file_name, opt => opt.MapFrom(x => x.file.name))
                                           .ForMember(dto => dto.file_type, opt => opt.MapFrom(x => x.file.type))
                                           .ForMember(dto => dto.file_url, opt => opt.MapFrom(x => s3Services.PresignedGet(x.file.url).Data.url))
                                           .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.user.last_name)).ReverseMap();
            CreateMap<PostModel, PostValidatorDTO>()
                                            .ForMember(dto => dto.job_title, opt => opt.MapFrom(x => x.job.title))
                                            .ForMember(dto => dto.job_type, opt => opt.MapFrom(x => x.job.job_type))
                                            .ForMember(dto => dto.file_url, opt => opt.MapFrom(x => s3Services.PresignedGet(x.file.url).Data.url))
                                            .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.user.last_name)).ReverseMap();
            CreateMap<PostModel, PostDetailsDTO>()
                                            .ForMember(dto => dto.file_type, opt=> opt.MapFrom(opt => ConvertFileType.Convert(opt.file.type)))
                                            .ForMember(dto => dto.job, opt => opt.MapFrom(x => x.job))
                                            .ForMember(dto => dto.file_url, opt => opt.MapFrom(x => s3Services.PresignedGet(x.file.url).Data.url))
                                            .ForMember(dto => dto.likes, opt => opt.MapFrom(x => x.likes.Select(l => l.post_id).Count()))
                                            .ForMember(dto => dto.avatar_author, opt => opt.MapFrom(x => s3Services.PresignedGet(x.user.avatar).Data.url))
                                            .ForMember(dto => dto.likes, opt => opt.MapFrom(x => x.likes.Select(l => l.post_id).Count()))
                                            .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.user.last_name))
                                            .ReverseMap();
            CreateMap<ReportModel, ReportDTO>()
                                           .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.post.id))
                                           .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.user.id))
                                           .ReverseMap();
            CreateMap<ReportModel, ReportByUserDTO>()
                                              .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.post.id))
                                              .ReverseMap();
            CreateMap<ApplicantModel,ApplicantDTO>().ReverseMap();
            CreateMap<ApplicantModel, ApplicantDetailsDTO>().ReverseMap();
        }
    }
}
