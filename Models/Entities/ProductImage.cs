using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class ProductImage : BaseEntity
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public string Url { get; set; }
    }
}