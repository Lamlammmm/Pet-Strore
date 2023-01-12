using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Product;

namespace PetStore.Service
{
    public interface IProducService
    {
        Task<IList<Product>> GetAll();

        Task<ProductModel> GetById(Guid id);

        Task<int> Create(ProductModel model);

        Task<int> Update(ProductModel model);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> id);

        Task<ApiResult<Pagingnation<ProductModel>>> GetAllPaging(ProductSeachContext ctx);
    }
}