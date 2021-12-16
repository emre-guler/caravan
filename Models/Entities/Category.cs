using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class Category : BaseEntity
    {
        [ForeignKey("MarketPlaceId")]
        public int MarketPlaceId { get; set; }

        [ForeignKey("CategoryId")]
        public int ParentId { get; set; }
        public string Name { get; set; }

        public virtual MarketPlace MarketPlace { get; set; }
    }
}