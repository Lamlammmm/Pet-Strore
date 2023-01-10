using Pet_Store.Data.Entities;

namespace Service.AboutDetailService
{
    public interface IAboutDetailService
    {
        Task<IList<AboutDetail>> GetAll();

        Task<AboutDetail> GetById(Guid id);

        Task<int> Create(AboutDetail model);

        Task<int> Update(AboutDetail model);

        Task<int> DeleteById(IEnumerable<Guid> id);
    }
}