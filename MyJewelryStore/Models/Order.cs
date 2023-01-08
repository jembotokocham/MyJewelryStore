using Microsoft.AspNetCore.Identity;

namespace MyJewelryStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int NewProductId { get; set; }
        public virtual NewProduct? NewProduct { get; set; }
        public string? UserId { get; set; }
        public virtual IdentityUser? User { get; set; }
        public virtual Status? Name { get; set; }
    }
}
