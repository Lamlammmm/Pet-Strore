using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IBannerService
    {
        Task<IList<Banner>> GetAll();

        Task<Banner> GetById(Guid id);

        Task<int> Create(Banner model);

        Task<int> Update(Banner model);

        Task<int> DeleteById(IEnumerable<Guid> id);
    }
}