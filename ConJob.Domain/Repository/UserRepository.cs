using ConJob.Data;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ConJob.Domain.DTOs.User;

namespace ConJob.Domain.Repository
{
    public class UserRepository: GenericRepository<UserModel>, IUserRepository
    {

        public UserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<UserModel> getUserByEmail(string email)
        {
            var user = await _context.users.Where(x => x.email == email).Include(x => x.user_roles).ThenInclude(x => x.role).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> updateAvatar(string? userid, string avatar)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.id == int.Parse(userid));
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
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserModel> updateAsync(UserInfoDTO userDTO, UserModel userModel)
        {
            var user = _mapper.Map(userDTO, userModel);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> findUserPostAsync(int user_id)
        {
            return await _context.users
                    .Include(c => c.posts)
                    .FirstAsync(c => c.id == user_id);
        }
    }
}
