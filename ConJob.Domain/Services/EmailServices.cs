﻿using ConJob.Domain.Authentication;
using ConJob.Entities;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;

namespace ConJob.Domain.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IJWTHelper _jWTHelper;
        private readonly IEmailSender _mailSender;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmailServices(IJWTHelper jWTHelper, IEmailSender mailSender, IHttpContextAccessor httpContextAccessor)
        {
            _jWTHelper = jWTHelper;
            _mailSender = mailSender;
            _httpContextAccessor = httpContextAccessor;
        }
        private string getBaseURL()
        {
            var request = _httpContextAccessor.HttpContext!.Request;
            var uri = $"api/v1/auth";
            return $"{request.Scheme}://{request.Host}{request.PathBase}/{uri}";
        }
        private string emailContent(string path)
        {
            string filePath = Directory.GetCurrentDirectory() + path;
            return File.ReadAllText(filePath);
        }
        public async Task sendActivationEmail(UserModel user)
        {
            var baseurl = getBaseURL();
            var token = await _jWTHelper.GenerateJWTMailAction(user.id, DateTime.UtcNow.AddDays(1), "confirm");
            var emailTemplateText = string.Format(emailContent("\\Email\\Templates\\Verified.html"), user.email, baseurl + "/verify/" + WebUtility.UrlEncode(token));
            BackgroundJob.Enqueue(() => _mailSender.SendEmailAsync(user.email, "Confirm Your Email", emailTemplateText));
        }
        public async Task sendForgotPassword(UserModel user)
        {
            var baseurl = getBaseURL();
            var token = await _jWTHelper.GenerateJWTMailAction(user.id, DateTime.UtcNow.AddDays(1), "forgot");
            var emailTemplateText = string.Format(emailContent("\\Email\\Templates\\Forgot.html"), user.email, baseurl + "/forgot/" + WebUtility.UrlEncode(token));
            BackgroundJob.Enqueue(() => _mailSender.SendEmailAsync(user.email, "Recover Your Password", emailTemplateText));
        }
    }
}