using ConJob.Data;
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

        public async Task<UserModel> getUserByEmail(UserLoginDTO u)
        {
            return await _context.User.Where(x => x.Email == u.Email).Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync();
        }
    }
}
