namespace ProductAPI.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string CategoryId { get; set; }
        public string? ProductCode { get; set; }
        public string ProductDescription { get; set; }
    }
}
