using ConJob.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public interface IEmailServices
    {
        Task sendActivationEmail(UserModel user, string baseurl);
        Task sendForgotPassword(UserModel user, string baseurl);
    }
}
