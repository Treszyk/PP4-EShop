namespace EShopService.Models
{
    public class Product : Base
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Ean { get; set; } = default!;
        public double Price { get; set; }
        public int Stock { get; set; } = 0;
        public string Sku { get; set; } = default!;
        public required Category Category { get; set; }
    }
}
