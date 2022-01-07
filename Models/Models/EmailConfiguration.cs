using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Caravan.Models
{
    public class EmailConfiguration
    {
        public EmailConfiguration()
        {
            From = "info@caravan.com";
            SmtpServer = "smtp.gmail.com";
            Port = 465;
            UserName = "info@caravan.com";
            Password = "123456789";
        }
        public string From { get; set; }
        public string To { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get ; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}