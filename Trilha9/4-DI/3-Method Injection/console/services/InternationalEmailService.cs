
using System.Globalization;
using System.Runtime.CompilerServices;
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
        private ITranslater translater;
        
        public InternationalEmailService(IConfiguration config)
        {
            this.configs = config.GetSection("Email").Get<EmailConfigurations>();
        }
        
        public void SetTranslater(ITranslater translater)
        {
            this.translater = translater;
        }

        public async Task Send(string subject, string message, string language)
        {
            message = await this.translater.Translate(message, language);

            MailMessage msg = new MailMessage
            {
                From = new MailAddress(configs.Sender, configs.DisplayName)
            };
        
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(message);

            msg.To.Add(new MailAddress(configs.Receiver, configs.DisplayName));
            msg.Subject = subject;
            msg.IsBodyHtml = false;
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
