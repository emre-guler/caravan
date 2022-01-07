using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Caravan.Interfaces;
using Caravan.Models;

namespace Caravan.Service
{
    public class MailService : IMailService
    {
        public void SendMail(EmailConfiguration config)
        {
            MailMessage message = new();
            SmtpClient smtp = new();
            message.From = new MailAddress(config.From);  
            message.To.Add(config.To);  
            message.Subject = config.Subject;  
            message.IsBodyHtml = true;   
            message.Body = config.Body;  
            smtp.Port = config.Port;  
            smtp.Host = config.SmtpServer;   
            smtp.EnableSsl = true;  
            smtp.UseDefaultCredentials = false;  
            smtp.Credentials = new NetworkCredential(config.UserName, config.Password);  
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
            smtp.Send(message);  
        }
    }
}