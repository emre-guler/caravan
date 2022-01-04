using System;

namespace Caravan.Entities
{
    public class Customer : BaseEntity 
    {
        // Caravan App Data
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress {get; set; }
        public string Password { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsMailAddressVerified { get; set; }

        // Trendyol Data
        public int? SellerId { get; set; } // SellerId ve SupplierId aynı şey.
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }   
        public DateTime? LastUpdateTrendyolData { get; set; } 
    }
}