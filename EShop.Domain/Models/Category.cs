namespace EShop.Domain.Models
{
    public class Category : Base
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
