using ConsimpleTestApi.DAL;
using ConsimpleTestApi.Models.DTO.Product;
using ConsimpleTestApi.Models.DTO.Purchase;
using ConsimpleTestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsimpleTestApi.BL.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CreatePurchaseRequest createProductRequest)
        {
            if (createProductRequest == null)
                throw new ArgumentNullException(nameof(createProductRequest));

            var user = await _context.Users.FindAsync(createProductRequest.UserId); // check if null

            var newPurchaseId = Guid.NewGuid();
            var productPurchase = createProductRequest
                .ProductsQuantity
                .Select(x => new ProductPurchaseEntity
                {
                    ProductId = x.ProductId,
                    PurchaseId = newPurchaseId,
                    Quantity = x.Quantity
                }).ToList();

            var newPurchase = new PurchaseEntity
            {
                Date = createProductRequest.PurchaseDate,
                TotalCost = createProductRequest.TotalCost, // do some calculations insted put in on request
                ProductPurchases = productPurchase,
                User = user,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _context.Purchases.AddAsync(newPurchase);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<PurchaseEntity>> GetAllAsync()
        {
            return await _context.Purchases.ToListAsync();
        }
    }
}
