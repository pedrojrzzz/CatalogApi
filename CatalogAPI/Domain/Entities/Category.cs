namespace APICatalogo.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; private set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
    }
}
