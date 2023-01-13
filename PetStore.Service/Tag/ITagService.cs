using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface ITagService
    {
        Task<IList<Tag>> GetAll();

        Task<Tag> GetById(Guid id);

        Task<int> Create(Tag model);

        Task<int> Update(Tag modil);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> ids);
    }
}