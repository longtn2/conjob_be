﻿using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Entities;
using AutoMapper;
using ConJob.Domain.DTOs.Follow;
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
                 .ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.token_hash_value, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap();
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.Roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.role).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();

            CreateMap<FollowModel, FollowDTO>()
               .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_follow.id))
               .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.from_user_follow.id)).ReverseMap();
            CreateMap<FollowModel, FollowDTO>()
                .ForMember(dest => dest.FromUserID, opt => opt.MapFrom(src => src.from_user_id))
                .ForMember(dest => dest.ToUserID, opt => opt.MapFrom(src => src.to_user_id)).ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
        }
    }
}
