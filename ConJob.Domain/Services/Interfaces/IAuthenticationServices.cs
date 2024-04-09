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
        Task<ServiceResponse<CredentialDTO>> LoginAsync(UserLoginDTO userdata);
        Task verifyEmailAsync(string userid);
        Task<ServiceResponse<Object>> activeEmailAsync(string Token);
        Task<ServiceResponse<TokenDTO>> refreshTokenAsync(string reftoken);
    }
}
