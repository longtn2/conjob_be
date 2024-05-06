using ConJob.Domain.DTOs.User;
using ConJob.Entities.Config;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services.Interfaces
{
    public interface IRocketChatServices
    {

        Task GetListGroup();
        Task CreateAccount(UserDTO u);
    }
}
