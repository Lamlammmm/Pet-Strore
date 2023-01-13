using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();

        Task<User> GetById(string id);

        Task<int> Create(User model);

        Task<int> Update(User model);

        Task<int> Delete(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> ids);
    }
}