using AutoMapper;
using ConJob.Domain.DTOs.Authentication;
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

            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest=>dest.Password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.Password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.TokenHashValue, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap(); 
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
        }
    }
}
