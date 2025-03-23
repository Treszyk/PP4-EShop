namespace EShopService.Models
{
    public class Base
    {
        public bool Deleted { get; set; }
        public DateTime Created_at { get; set; }
        public Guid Created_by { get; set; }
        public DateTime Updated_at { get; set; }
        public Guid Updated_by { get; set; }
    }
}
