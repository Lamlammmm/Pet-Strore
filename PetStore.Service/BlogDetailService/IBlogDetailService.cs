using Pet_Store.Data.Entities;
using PetStore.Model.BlogDetail;

namespace PetStore.Service
{
    public interface IBlogDetailService
    {
        Task<IList<BlogDetail>> GetAll();

        Task<BlogDetail> GetById(Guid id);

        Task<int> Create(BlogDetailModel model);

        Task<int> Update(BlogDetailModel model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
    }
}