using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Product;

namespace PetStore.Service
{
    public interface IProducService
    {
        Task<IList<Product>> GetAll();

        Task<Product> GetById(Guid id);

        Task<int> Create(Product model);

        Task<int> Update(Product model);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> id);

        Task<ApiResult<Pagingnation<Product>>> GetAllPaging(ProductSeachContext ctx);
    }
}