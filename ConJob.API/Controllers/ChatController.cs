using ConJob.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConJob.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[Controller]/")]
    public class ChatController : Controller
    {

        private readonly IRocketChatServices _rocket;
        
        public ChatController(IRocketChatServices rocket)
        {
            _rocket = rocket;
        }
        [Route("test")]
        [Produces("application/json")]
        [HttpPost]
        public void ra()
        {
            Random rnd = new Random();
            var room_id = _rocket.CreateNewRoom($"CJ_congviectuyetvoi_{rnd.Next(1,1000).ToString()}", new List<string> {"tuanvynguyen1", "lunanacaoz" });
            var a = "test";
        }
    }
}
