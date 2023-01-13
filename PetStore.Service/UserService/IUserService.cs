using Pet_Store.Data.Entities;
using PetStore.Model;

namespace PetStore.Service
{
    public interface IUserService
    {
        Task<IList<User>> GetAll();

        Task<User> GetById(string id);

        Task<int> Create(UserModel model);

        Task<int> Update(UserModel model);

        Task<int> Delete(string id);

        Task<int> DeleteByIds(IEnumerable<string> ids);
    }
}