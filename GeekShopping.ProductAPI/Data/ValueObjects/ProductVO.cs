namespace GeekShopping.ProductAPI.Data.ValueObjects
{
    public class ProductVO
    {
        public long Id { get; set; }
        public required string Name { get; set; } 
        public decimal Price { get; set; }
        public required string Description { get; set; }    
        public required string CategoryName { get; set; }       
        public required string ImageUrl { get; set; }
    }
}
