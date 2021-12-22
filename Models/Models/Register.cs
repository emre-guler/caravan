using System.ComponentModel.DataAnnotations;

namespace Caravan.Model
{
    public class Register : BaseModel
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}