namespace Caravan.Models
{
    public class Profile : BaseModel
    {
        public string FullName { get; set; }
        public string MailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsMailAddressVerified { get; set; }
    }
}