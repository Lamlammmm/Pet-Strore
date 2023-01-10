using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.About;

namespace PetStore.Service
{
    public interface IAboutService
    {
        Task<IList<About>> GetAll();
        Task<About> GetById(Guid id);
        Task<int> Create(About model);
        Task<int> Update(About model);
        Task<int> DeleteById(IEnumerable<Guid> id);
        Task<ApiResult<Pagingnation<About>>> GetPaging(AboutSeachContext ctx);
    }
}