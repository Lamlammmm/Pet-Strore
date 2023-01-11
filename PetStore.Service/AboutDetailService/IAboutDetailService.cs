using Pet_Store.Data.Entities;
using PetStore.Model.AboutDetail;

namespace PetStore.Service
{
    public interface IAboutDetailService
    {
        Task<IList<AboutDetail>> GetAll();

        Task<AboutDetail> GetById(Guid id);

        Task<int> Create(AboutDetailModel model);

        Task<int> Update(AboutDetailModel model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
    }
}