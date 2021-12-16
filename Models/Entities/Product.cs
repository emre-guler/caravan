using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class Product : BaseEntity
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("MarketPlaceId")]
        public int MarketPlaceId { get; set; }
        
        public string Barcode { get; set; }
        public string Title { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string StockCode { get; set; }
        public double DimensionalWeight { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public double ListPrice { get; set; }
        public double SalePrice { get; set; }
        public int? DeliveryDuration { get; set; }
        public int VatRate { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual MarketPlace MarketPlace { get; set; }
    }
}