using ConsimpleTestApi.Models.DTO.Product;
using ConsimpleTestApi.Models.Entities;

namespace ConsimpleTestApi.BL.Product
{
    public interface IProductService
    {
        public Task CreateAsync(CreateProductRequest createProductRequest);

        public Task<ICollection<ProductEntity>> GetAllAsync();
    }
}
