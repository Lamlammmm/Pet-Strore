using Pet_Store.Data.Entities;
using PetStore.Model.ProductDetail;

namespace PetStore.Service
{
    public interface IProductDetailService
    {
        Task<IList<ProductDetail>> GetAll();

        Task<ProductDetail> GetById(Guid id);

        Task<int> Create(ProductDetailModel model);

        Task<int> Update(ProductDetailModel model);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
    }
}