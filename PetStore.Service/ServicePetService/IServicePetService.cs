using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;

namespace PetStore.Service
{
    public interface IServicePetService
    {
        Task<IList<ServicePet>> GetAll();

        Task<ServicePet> GetById(Guid id);

        Task<int> Create(ServicePet model);

        Task<int> Update(ServicePet model);

        Task<int> DeleteById(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<ApiResult<Pagingnation<ServicePet>>> GetAllPaging(ServicePetSeachContext ctx);
    }
}