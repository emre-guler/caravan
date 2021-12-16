namespace Caravan.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsMailVerfied { get; set; }
    }   
}