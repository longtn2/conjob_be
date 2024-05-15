using Azure;
using ConJob.Domain.Constant;
using ConJob.Domain.DTOs.Rocketchat;
using ConJob.Domain.DTOs.RocketChat;
using ConJob.Domain.DTOs.User;
using ConJob.Domain.Repository;
using ConJob.Domain.Repository.Interfaces;
using ConJob.Domain.Services.Interfaces;
using ConJob.Entities;
using ConJob.Entities.Config;
using ConJob.Entities.Utils.JSON;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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

        public async Task<string> CreateAccount(UserModel user)
        {
            try
            {
                var headers = RocketAuth();
                var payload = new
                {
                    name = user.first_name + " " + user.last_name,
                    email = user.email,
                    password = "",
                    username = user.email.Split('@')[0],
                    roles = new[]
                    {
                    "user"
                },
                    setRandomPassword = true
                };
                string body = await SendRequest(HttpMethod.Post, "api/v1/users.create", headers, JsonConvert.SerializeObject(payload));

                NewUserDTO? data = JsonConvert.DeserializeObject<NewUserDTO>(JsonUtils.GetData(body, CJConstant.ROCKET_CHAT_USER));
                return data._id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error parsing JSON response from Rocket.Chat " + ex.Message);
                throw;
            }
        }
        public async Task ObtainCredentialToken(UserModel user)
        {
            try
            {
                string id = await CreateAccount(user);
                var headers = RocketAuth();
                var payload = new
                {
                    userId = id
                };
                string body = await SendRequest(HttpMethod.Post, "api/v1/users.createToken", headers, JsonConvert.SerializeObject(payload));
                CreateTokenDTO? data = JsonConvert.DeserializeObject<CreateTokenDTO>(JsonUtils.GetData(body, CJConstant.ROCKET_CHAT_DATA));

                await _userRepository.updateRocketChatToken(user.id.ToString(), data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error parsing JSON response from Rocket.Chat " + ex.Message);
                throw;
            }
        }
        public async Task<string> CreateNewRoom(string RoomName, List<string> Users)
        {
            try
            {
                var headers = RocketAuth();
                var payload = new
                {
                    name = RoomName,
                    members = Users,
                    type = 1
                };
                string body = await SendRequest(HttpMethod.Post, "api/v1/teams.create", headers, JsonConvert.SerializeObject(payload));

                TeamCreateDTO? data = JsonConvert.DeserializeObject<TeamCreateDTO>(JsonUtils.GetData(body, CJConstant.ROCKET_CHAT_TEAM));
                return data!._id;
            }
            catch
            {
                throw;
            }
        }
    }
}
