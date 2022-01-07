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
        public string From { get; }
        public string To { get; set; }
        public string SmtpServer { get;  }
        public int Port { get; }
        public string UserName { get;  }
        public string Password { get;  }
        public string Subject { get ; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}