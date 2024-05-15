using AutoMapper;
using ConJob.Data;
using ConJob.Domain.DTOs.Rocketchat;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConJob.Domain.Repository
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
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
            try
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
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public async Task updateAsync(UserModel user, UserInfoDTO updateUser)
        {
            user.first_name = updateUser.first_name;
            user.last_name = updateUser.last_name;
            user.phone_number = updateUser.phone_number;
            user.address = updateUser.address;
            user.dob = updateUser.dob;
            user.gender = updateUser.gender;
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> findUserPostAsync(int user_id)
        {
            return await _context.users
                    .Include(c => c.posts)
                    .FirstAsync(c => c.id == user_id);
        }

        public async Task<UserModel> GetDetailsUserAsync(int user_id)
        {
            return await _context.users.Include(c => c.posts)
                                            .ThenInclude(p => p.file)
                                        .Include(c => c.posts)
                                            .ThenInclude(p => p.job)
                                        .Include(c => c.jobs)
                                            .ThenInclude(j => j.posts)
                                        .Include(c => c.followers)
                                        .Include(c => c.following)
                                        .Include(c => c.personal_skills)
                                            .ThenInclude(p => p.skill)
                                        .Include(c => c.user_roles)
                                            .ThenInclude(r => r.role)
                                        .FirstAsync(c => c.id == user_id);
        }

        public async Task<UserModel> GetUserNotIsAdminAsync(int id)
        {
            var user = await _context.user_roles.Where(x => x.user_id == id && x.role_id != 1).Select(u => u.user).FirstOrDefaultAsync();
            return user;
        }

        public int GetRoleByUserId(int id)
        {
            return _context.user_roles.Where(u => u.user_id == id).Select(u => u.role_id).FirstOrDefault();
        }

        public IQueryable<SkillModel> GetSkillsAsync(int userid)
        {
             return _context.persional_skills.Where(e=>e.user_id==userid).Select(e=>e.skill);
        }
        public async Task<bool> updateRocketChatToken(string userid, CreateTokenDTO token)
        {
            try
            {
                var user = await _context.users.FirstOrDefaultAsync(x => x.id == int.Parse(userid));
                if (user != null)
                {
                    user.rocket_auth_token = token.authToken;
                    user.rocket_user_id = token.userId;
                }
                else
                {
                    return false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
