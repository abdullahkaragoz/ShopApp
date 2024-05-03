namespace ShopApp.Catalog.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public string ProcutID { get; set; }
        public string ProcutName { get; set; }
        public decimal ProcutPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; } 
    }
}
