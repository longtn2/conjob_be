using ConJob.Domain.DTOs.User;
using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConJob.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ChatController
    {
        private readonly IRocketChatServices _rocketChatServices;

        public ChatController(IRocketChatServices rocketChatServices) {
            _rocketChatServices = rocketChatServices;   
        }


        [HttpGet("Test")]

        public void Get()
        {
            UserDTO u = new UserDTO()
            {
                first_name = "Nguyễn Thị",
                last_name = "Ngọc Ánh",
                email = "Test@gmail1232434.com",


            };
            _rocketChatServices.CreateAccount(u);

        }
    }
}
