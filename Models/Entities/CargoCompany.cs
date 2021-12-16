using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class CargoCompany : BaseEntity
    {
        [ForeignKey("MarketPlaceId")]
        public int MarketPlaceId { get; set; }

        public int MarketPlaceCargoCompanyId { get; set;}
        public string Name { get; set; }
        public string Code { get; set; }
        public string TaxNumber { get; set; }

        public virtual MarketPlace MarketPlace { get; set; }
    }
}