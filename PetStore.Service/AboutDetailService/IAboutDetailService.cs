using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IAboutDetailService
    {
        Task<IList<AboutDetail>> GetAll();

        Task<AboutDetail> GetById(Guid id);

        Task<int> Create(AboutDetail model);

        Task<int> Update(AboutDetail model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
    }
}