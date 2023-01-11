using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IBlogDetailService
    {
        Task<IList<BlogDetail>> GetAll();

        Task<BlogDetail> GetById(Guid id);

        Task<int> Create(BlogDetail model);

        Task<int> Update(BlogDetail model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
    }
}