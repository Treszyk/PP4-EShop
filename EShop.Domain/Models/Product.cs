using System.ComponentModel.DataAnnotations;

namespace EShop.Domain.Models
{
    public class Product : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        public string Ean { get; set; } = default!;
        public double Price { get; set; }
        public int Stock { get; set; } = 0;
        public string Sku { get; set; } = default!;
        public Category Category { get; set; } = default!;
    }
}
