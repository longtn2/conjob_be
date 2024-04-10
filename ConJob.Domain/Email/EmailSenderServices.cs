using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using MimeKit;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Runtime;
using Org.BouncyCastle.Asn1.Pkcs;
using MailKit.Net.Smtp;
using ConJob.Entities.Config;
using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;

namespace DataLayer.Email
{
    public class EmailSenderServices : IEmailSender
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<EmailSenderServices> _logger;  
        public EmailSenderServices(IOptions<MailSettings> mailSettings, ILogger<EmailSenderServices> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }
        public async Task SendEmailAsync(string email, string subject, string html)
        {

            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);

                    MailboxAddress emailTo = new MailboxAddress(email, email);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Subject = "Hello";
                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = html;
                    emailBodyBuilder.TextBody = "Plain Text goes here to avoid marked as spam for some email servers.";

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }

            }
            catch (Exception ex)
            {
                // Exception Details
                _logger.LogError($"Error Occured: {ex.Message}");
            }
        }
        
    }
}
