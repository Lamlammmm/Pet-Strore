using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;
using PetStore.Model.Banner;

namespace PetStore.Service
{
    public interface IBannerService
    {
        Task<IList<BannerModel>> GetAll();

        Task<BannerModel> GetById(Guid id);

        Task<int> Create(BannerModel model);

        Task<int> Update(BannerModel model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
        Task<ApiResult<Pagingnation<Banner>>> GetAllPaging(BannerSeachContext ctx);
    }
}