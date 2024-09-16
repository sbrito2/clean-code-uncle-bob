
using System;
using System.Net.Mail;
using System.Net;
using console.models;
using Microsoft.Extensions.Configuration;
using PDG.Infraestructure.Data.Services;
using System.Threading.Tasks;
using console.interfaces;

namespace console.Domain.Services
{
    public class InternationalEmailService 
    {
        private readonly EmailConfigurations configs;
        public ITranslater translater;
        
        public InternationalEmailService(IConfiguration config, ITranslater translater)
        {
            this.configs = config.GetSection("Email").Get<EmailConfigurations>();
            this.translater = translater;
        }

        public async Task Send(string subject, string message, bool isBodyHtml = false)
        {
            message = await translater.Translate(message);

            MailMessage msg = new MailMessage
            {
                From = new MailAddress(configs.Sender, configs.DisplayName)
            };

            msg.To.Add(new MailAddress(configs.Receiver, configs.DisplayName));
            msg.Subject = subject;
            msg.IsBodyHtml = isBodyHtml;
            msg.Body = message;

            try
            {
                using (SmtpClient smtpclient = new SmtpClient(configs.Host, configs.Port))
                {
                    smtpclient.Credentials = new NetworkCredential(configs.Sender,configs.Password);
                    smtpclient.EnableSsl = true;
                    smtpclient.Send(msg);   
                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}
