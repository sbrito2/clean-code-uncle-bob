
using System;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using API.CrossCutting.Utils.Email;
using API.CrossCutting.Utils.Security.Exceptions;
using API.Application.Services;
using System.Net;
using API.Domain.Projections.Email;

namespace API.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigurations configs;
        public EmailService(IOptions<EmailConfigurations> configs)
        {
            this.configs = configs.Value;
        }

        public void Send(string subject, string message, bool isBodyHtml = false)
        {
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
                throw new UnprocessableException("O e-mail informado não é válido.");
            }
        }

        public void SendCustomerEmail(EmailProjectionModel customerEmail)
        {
            string title = "Email de dúvida - Mestre dos leilões";
            string messagem = $" Nome: {customerEmail.Name} \n Email: {customerEmail.Email} \n Mensagem: {customerEmail.Message}";
            
            this.Send(title, messagem, false); 
        }
    }
}
