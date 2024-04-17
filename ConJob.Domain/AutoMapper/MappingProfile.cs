﻿using ConJob.Domain.DTOs.Authentication;
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

            CreateMap<UserRegisterDTO, UserModel>().ForMember(dest=>dest.password, opt => opt.MapFrom(scr => _pwdHasher.Hash(scr.password)));
            CreateMap<UserModel, UserDTO>()
                 .ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.roles).ToList()));
            CreateMap<JwtDTO, JWTModel>().ForMember(dest => dest.token_hash_value, opt => opt.MapFrom(src => _pwdHasher.Hash(src.Token)));
            ////Reverse can map from 1->2 || 2->1
            CreateMap<UserModel, UserInfoDTO>().ReverseMap(); 
            CreateMap<UserModel, CredentialDTO>().ForMember(dto => dto.roles, opt => opt.MapFrom(x => x.user_roles.Select(y => y.roles).ToList())).ReverseMap();
            CreateMap<RoleModel, RolesDTO>().ReverseMap();
            CreateMap<PostModel, PostDTO> ().ForMember(dto => dto.name_file, opt => opt.MapFrom(x => x.files.name))
                                            .ForMember(dto => dto.type_file, opt => opt.MapFrom(x => x.files.type))
                                            .ForMember(dto => dto.url_file, opt => opt.MapFrom(x => x.files.url))
                                            .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.users.last_name)).ReverseMap();
            CreateMap<PostModel, PostDetailsDTO>()
                                            .ForMember(dto => dto.name_file, opt => opt.MapFrom(x => x.files.name))
                                            .ForMember(dto => dto.type_file, opt => opt.MapFrom(x => x.files.type))
                                            .ForMember(dto => dto.url_file, opt => opt.MapFrom(x => x.files.url))
                                            .ForMember(dto => dto.likes, opt => opt.MapFrom(x => x.likes.Select(l => l.post_id).Count()))
                                            .ForMember(dto => dto.author, opt => opt.MapFrom(x => x.users.last_name)).ReverseMap();

            CreateMap<SkillModel, SkillDTO>().ReverseMap();
        }
    }
}
