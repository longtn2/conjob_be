using ConJob.Domain.Authentication;
using ConJob.Entities;
using Hangfire;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Services
{
    public class EmailServices: IEmailServices
    {
        private readonly IJWTHelper _jWTHelper;
        private readonly IEmailSender _mailSender;
        public EmailServices(IJWTHelper jWTHelper, IEmailSender mailSender)
        {
            _jWTHelper = jWTHelper;
            _mailSender = mailSender;
        }

        public async Task sendActivationEmail(UserModel user, string baseurl)
        {
            var token = await _jWTHelper.GenerateJWTMailAction(user.Id, DateTime.UtcNow.AddDays(1), "confirm");
            

            string filePath = Directory.GetCurrentDirectory() + "\\Email\\Templates\\Verified.html";
            string emailTemplateText = File.ReadAllText(filePath);

            emailTemplateText = string.Format(emailTemplateText, user.Email, baseurl+"/verify/"+ WebUtility.UrlEncode(token));
            BackgroundJob.Enqueue(() => _mailSender.SendEmailAsync(user.Email, "Confirm Your Email", emailTemplateText));
        }
        public async Task sendForgotPassword(UserModel user, string baseurl)
        {
            var token = await _jWTHelper.GenerateJWTMailAction(user.Id, DateTime.UtcNow.AddDays(1), "forgot");

            string filePath = Directory.GetCurrentDirectory() + "\\Email\\Templates\\Forgot.html";

            string emailTemplateText = File.ReadAllText(filePath);

            emailTemplateText = string.Format(emailTemplateText, user.Email, baseurl + "/forgot/" + WebUtility.UrlEncode(token));

            BackgroundJob.Enqueue(() => _mailSender.SendEmailAsync(user.Email, "Recover Your Password", emailTemplateText));
        }
    }
}
