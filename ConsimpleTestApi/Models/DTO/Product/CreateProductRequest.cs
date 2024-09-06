using ConsimpleTestApi.Models.Enums;

namespace ConsimpleTestApi.Models.DTO.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;

        public string Article { get; set; } = null!;

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}
