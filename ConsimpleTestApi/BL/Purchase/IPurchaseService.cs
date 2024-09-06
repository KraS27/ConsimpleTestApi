using ConsimpleTestApi.Models.DTO.Purchase;
using ConsimpleTestApi.Models.Entities;

namespace ConsimpleTestApi.BL.Purchase
{
    public interface IPurchaseService
    {
        public Task CreateAsync(CreatePurchaseRequest createProductRequest);

        public Task<ICollection<PurchaseEntity>> GetAllAsync();
    }
}
