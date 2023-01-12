using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.About;

namespace PetStore.Service
{
    public interface IAboutService
    {
        Task<IList<About>> GetAll();
        Task<AboutModel> GetById(Guid id);
        Task<int> Create(AboutModel model);
        Task<int> Update(AboutModel model);
        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
        Task<ApiResult<Pagingnation<AboutModel>>> GetPaging(AboutSeachContext ctx);
    }
}