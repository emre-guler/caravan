using System.ComponentModel.DataAnnotations.Schema;

namespace Caravan.Entities
{
    public class CustomerRoleCustomerMapping : BaseEntity
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerRole CustomerRole { get; set; }
    } 
}