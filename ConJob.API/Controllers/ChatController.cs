using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ConJob.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/v{version:apiVersion}/chat/")]
    public class ChatController : ControllerBase
    {
        private readonly string _rocketChatBaseUrl = "http://192.168.150.132:3000";
        private readonly string _username = "lethingocanh17072003@gmail.com";
        private readonly string _password = "ngocanh1234";

        [HttpPost]
        public IActionResult SendMessage(string receiver, string message)
        {
            // Authenticate with Rocket.Chat
            var responseData = AuthenticateWithRocketChat();             
            if (responseData == null)             
            {                 
                return BadRequest("Failed to authenticate with Rocket.Chat");             
            }             
            //Send message
            var client = new RestClient(_rocketChatBaseUrl);
            var request = new RestRequest("/api/v1/chat.postMessage", Method.Post);
            request.AddHeader("X-Auth-Token", responseData["data"]["authToken"].ToString());             
            request.AddHeader("X-User-Id", responseData["data"]["userId"].ToString());             
            request.AddJsonBody(new            
            {                 
                channel = "@" + receiver,                 
                text = message             
            });             
            var response = client.Execute(request);             
            if (response.IsSuccessful)             
            {                 
                return Ok("Message sent successfully");             
            }             
            else            
            {                 
                return StatusCode((int)response.StatusCode, "Failed to send message: " + response.Content);             
            }
        }

        private JObject AuthenticateWithRocketChat()
        {
            var client = new RestClient(_rocketChatBaseUrl); 
            var request = new RestRequest("/api/v1/login", Method.Post); 
            request.AddJsonBody(new { user = _username, password = _password }); 
            var response = client.Execute(request); 
            if (response.IsSuccessful) 
            { 
                return JObject.Parse(response.Content);
            } 
            else 
            { 
                Console.WriteLine("Failed to authenticate with Rocket.Chat: " + response.Content); 
                return null; 
            }
        }
    }
}
