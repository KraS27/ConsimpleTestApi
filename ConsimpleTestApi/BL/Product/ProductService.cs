using ConsimpleTestApi.DAL;
using ConsimpleTestApi.Models.DTO.Product;
using ConsimpleTestApi.Models.DTO.User;
using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestApi.BL.Product
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreateProductRequest createProductRequest)
        {
            if (createProductRequest == null)
                throw new ArgumentNullException(nameof(createProductRequest));

            var newProduct = new ProductEntity
            {
                Name = createProductRequest.Name,
                Article = createProductRequest.Article,
                Price = createProductRequest.Price,
                Category = createProductRequest.Category,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
