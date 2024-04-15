using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;

namespace ConJob.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        private readonly IPasswordHasher _pwdHasher;
/*        private readonly IFollowRepository _followRepository;*/
        public MappingProfile(IPasswordHasher pwdHasher)
        {
            _pwdHasher = pwdHasher;
       /*     _followRepository = followRepository;*/
            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest => dest.Password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.Password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.TokenHashValue, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap();
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();

            CreateMap<FollowModel, FollowDTO>()
            .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.FromUserID))
            .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.ToUserID)).ReverseMap();

/*            CreateMap<FollowDTO, FollowModel>()
                .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.FromUserID))
                .ForMember(dest => dest.FromUser, opt => opt.MapFrom(scr => _followRepository.GetById(scr.FromUserID)))
                .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.ToUserID))
                .ForMember(dest => dest.ToUser, opt => opt.MapFrom(scr => _followRepository.GetById(scr.ToUserID)));*/

            CreateMap<ReportModel, ReportDTO>()
                  .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.Post.Id)) 
                  .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.User.Id)) 
                  .ReverseMap();
            CreateMap<ReportModel, ReportByUserDTO>()
              .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.Post.Id))
              .ReverseMap();
        }
    }
}
