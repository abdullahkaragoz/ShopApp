namespace ShopApp.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProcutName { get; set; }
        public decimal ProcutPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
