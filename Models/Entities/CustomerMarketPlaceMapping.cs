using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class CustomerMarketPlaceMapping : BaseEntity
    {
        [ForeignKey("UserId")]
        public int CustomerId { get; set; }
        [ForeignKey("MarketPlaceId")]
        public int MarketPlaceId { get; set; }


        public int SellerId { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual MarketPlace MarketPlace { get; set; }
    }
}