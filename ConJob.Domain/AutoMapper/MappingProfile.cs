﻿using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.Post;
using ConJob.Domain.DTOs.Role;
using ConJob.Domain.DTOs.Skill;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Entities;
using AutoMapper;
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
            CreateMap<PostModel, PostDTO> ().ForMember(dto => dto.NameFile, opt => opt.MapFrom(x => x.File.Name))
                                            .ForMember(dto => dto.Type_File, opt => opt.MapFrom(x => x.File.Type))
                                            .ForMember(dto => dto.Author, opt => opt.MapFrom(x => x.User.LastName)).ReverseMap();
            CreateMap<PostModel, PostDetailsDTO>()
                                            .ForMember(dto => dto.NameFile, opt => opt.MapFrom(x => x.File.Name))
                                            .ForMember(dto => dto.Type_File, opt => opt.MapFrom(x => x.File.Type)).ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
        }
    }
}
