namespace ProductAPI.Dtos
{
    public class ProductDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? Picture { get; set; }
        public string? ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public string? Description { get; set; }
    }
}
