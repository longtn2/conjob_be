using ConJob.Domain.DTOs.Authentication;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public interface IAuthenticationServices
    {
        /// <summary>
        /// Verify Login information of user.
        /// </summary>
        /// <param name="userdata">User login data include: Username, Password.</param>

        Task<ServiceResponse<CredentialDTO>> LoginAsync(UserLoginDTO userdata);
        /// <summary>
        /// Send an email with activation link to user email box.
        /// </summary>
        /// <param name="userid">The id collect from Cookie of User request.</param>

        Task verifyEmailAsync(string userid);
        /// <summary>
        /// Verify token attach in mail box. If it's valid then change the user email confirm to True
        /// </summary>
        /// <param name="Token">Token attach in the email box.</param>

        Task<ServiceResponse<Object>> activeEmailAsync(string Token);

        /// <summary>
        /// When ever token of user expire. This method verify refreshtoken to reissue new short term token.
        /// </summary>
        /// <param name="reftoken">Long term token store in User storage.</param>

        Task<ServiceResponse<TokenDTO>> refreshTokenAsync(string reftoken);

        /// <summary>
        /// Send an email with forgot link to user email box;
        /// </summary>
        /// <param name="usermail">Thông tin đăng nhập của người dùng</param>
        Task<ServiceResponse<Object>> sendForgotEmailVerify(string useremail);

        Task<ServiceResponse<Object>> RecoverPassword(string Token, string new_password);


        ServiceResponse<Object> Logout(string token);
    }
}
