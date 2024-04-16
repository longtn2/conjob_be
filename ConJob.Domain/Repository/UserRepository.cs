﻿using ConJob.Data;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ConJob.Domain.Repository
{
    public class UserRepository: GenericRepository<UserModel>, IUserRepository
    {

        public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserModel> getUserByEmail(string email)
        {
            var user =  await _context.Users.Where(x => x.email == email).Include(x => x.user_roles).ThenInclude(x => x.roles).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> updateAvatar(string? userid, string avatar)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.id == int.Parse(userid));

            if (user != null)
            {
                user.avatar = avatar;
            }
            else
        {
                return false;
            }
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> changPasswordAsync(string newPassword, UserModel user)
        {
            try
            {
                user.password = newPassword;
                await _context.SaveChangesAsync();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
