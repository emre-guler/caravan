using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class CustomerRole : BaseEntity
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Customer Customer { get; set; }
    } 
}