using Azure;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using ConJob.Entities.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ConJob.Domain.Services
{
    public class RocketChatServices : IRocketChatServices
    {
        private readonly RocketChatSettings _rocketSettings;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public RocketChatServices(IOptions<RocketChatSettings> rocketSettings, IUserRepository userRepository, ILogger<UserServices> logger)
        {
            _rocketSettings = rocketSettings.Value;
            _userRepository = userRepository;
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

        public async Task<string> CreateAccount(UserRegisterDTO user)
        {
            var headers = RocketAuth();
            var payload = new
            {
                name = user.first_name + " " + user.last_name,
                email = user.email,
                password = "",
                username = user.email.Split('@')[0] ,
                roles = new[]
                {
                    "user"
                },
                setRandomPassword = true
            };
            string body = await SendRequest(HttpMethod.Post, "api/v1/users.create", headers, JsonSerializer.Serialize(payload)); 
            try
            {
                var responseJson = JsonDocument.Parse(body);
                var userId = responseJson.RootElement.GetProperty("user").GetProperty("_id").GetString();
                _logger.LogInformation(body);
                return userId;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error parsing JSON response from Rocket.Chat " + ex.Message);
                throw;
            }
        }

        public async Task UpdateUserAccount(int userId)
        {
            var user = _userRepository.GetById(userId);
            var headers = RocketAuth();
            headers.Add("x-2fa-code", "363-617");
            var payload = new
            {
                userId = user.rocket_user_id,
                data = new
                {
                    name = $"{user.first_name} {user.last_name}"
                }
            };
            string body = await SendRequest(HttpMethod.Post, "api/v1/users.update", headers, JsonSerializer.Serialize(payload));
            _logger.LogInformation(body);
        }

        public async Task<string> CreateAuthToken(string userId)
        {
            var headers = RocketAuth();
            var payload = new
            {
                userId = userId
            };
            string body = await SendRequest(HttpMethod.Post, "api/v1/users.createToken", headers, JsonSerializer.Serialize(payload));
            try
            {
                var responseJson = JsonDocument.Parse(body);
                var authToken = responseJson.RootElement.GetProperty("data").GetProperty("authToken").GetString();
                _logger.LogInformation(body);
                return authToken;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error parsing JSON response from Rocket.Chat " + ex.Message);
                throw;
            }
        }
    }
}
