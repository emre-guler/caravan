using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class CustomerSupplierAddress : BaseEntity
    {
        // Supplier's data will keep in CustomJsonAttribute.
        
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}