using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Entities;
using AutoMapper;
using ConJob.Domain.DTOs.Report;
namespace ConJob.Domain.AutoMapper
{
    public class MappingProfile :Profile
    {
        private readonly IPasswordHasher _pwdHasher;
        public MappingProfile(IPasswordHasher pwdHasher)
        {
            _pwdHasher = pwdHasher;
            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest => dest.password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.Password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.token_hash_value, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap();
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
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
