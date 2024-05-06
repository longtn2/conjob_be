using BCrypt.Net;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Encryption;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public class RocketChatServices : IRocketChatServices
    {
        private readonly RocketChatSettings _rocketSettings;
        private readonly ILogger _logger;
        public RocketChatServices(IOptions<RocketChatSettings> rocketSettings, ILogger<UserServices> logger)
        {
            _rocketSettings = rocketSettings.Value;
            _logger = logger;
        }

        private async Task<string> SendRequest(HttpMethod method, string uri, IDictionary<string, string> header, string content)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = new Uri($"{_rocketSettings.BaseURL}/{uri}");

                foreach (var (key, value) in header)
                {
                    request.Headers.Add(key, value);
                }
                var payload = new StringContent(content, null, "application/json");
                request.Content = payload;
                var response = await client.SendAsync(request);

/*                response.EnsureSuccessStatusCode();*/
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        private IDictionary<string, string> RocketAuth()
        {
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("X-Auth-Token", _rocketSettings.AuthToken);
            headers.Add("X-User-Id", _rocketSettings.UserID);
            return headers;
        }
        public async Task GetListGroup()
        {
            var headers = RocketAuth();
            var payload = "";
            string body = await SendRequest(HttpMethod.Get, "api/v1/groups.list", headers, payload);
        }

        public async Task CreateAccount(UserDTO u)
        {
            var headers = RocketAuth();

            var payload = new
            {
                name = u.first_name + " " + u.last_name,
                email = u.email,
                password = "",
                username = u.email.Split('@')[0] ,
                roles = new[]
                {
                    "user"
                },
                setRandomPassword = true
            };
            string body = await SendRequest(HttpMethod.Post, "api/v1/users.create", headers, JsonSerializer.Serialize(payload));
            _logger.LogInformation(body);
        }
    }
}
