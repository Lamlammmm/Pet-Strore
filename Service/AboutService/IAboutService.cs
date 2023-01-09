using Pet_Store.Data.Entities;
using PetStore.Common.Common;

namespace Service.AboutService
{
    public interface IAboutService
    {
        Task<IList<About>> GetAll();
        Task<About> GetById(Guid id);
        Task<int> Create(About model);
        Task<int> Update(About model);
        Task<int> DeleteById(Guid id);
        Task<ApiResult<Pagingnation<About>>> GetPaging(About model);
    }
}