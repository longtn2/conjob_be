using ConJob.Domain.DTOs.Authentication;
﻿using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Follow;
using ConJob.Domain.DTOs.Report;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using AutoMapper;
namespace ConJob.Domain.AutoMapper
{
    public class MappingProfile :Profile
    {
        private readonly IPasswordHasher _pwdHasher;
/*        private readonly IFollowRepository _followRepository;*/
        public MappingProfile(IPasswordHasher pwdHasher)
        {
            _pwdHasher = pwdHasher;
            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest => dest.password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.roles).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.token_hash_value, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap();
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.roles).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();

            CreateMap<FollowModel, FollowDTO>()
            .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_follows.id))
            .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.from_user_follows.id)).ReverseMap();



            CreateMap<ReportModel, ReportDTO>()
                  .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.posts.id)) 
                  .ForMember(dest => dest.user_id, opt => opt.MapFrom(src => src.users.id)) 
                  .ReverseMap();
            CreateMap<ReportModel, ReportByUserDTO>()
              .ForMember(dest => dest.post_id, opt => opt.MapFrom(src => src.posts.id))
              .ReverseMap();
        }
    }
}
