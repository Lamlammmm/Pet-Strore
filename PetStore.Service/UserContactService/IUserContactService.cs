using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IUserContactService
    {
        Task<int> Create(UserContact model);
    }
}