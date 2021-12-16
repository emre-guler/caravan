using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class Brand : BaseEntity
    {
        [ForeignKey("MarketPlaceId")]
        public int MarketPlaceId { get; set; }

        public int MarketPlaceBrandId { get; set; }
        public string Name { get; set; }

        public virtual MarketPlace MarketPlace { get; set; }
    }
}