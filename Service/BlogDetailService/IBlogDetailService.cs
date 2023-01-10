using Pet_Store.Data.Entities;

namespace Service.BlogDetailService
{
    public interface IBlogDetailService
    {
        Task<IList<BlogDetail>> GetAll();

        Task<BlogDetail> GetById(Guid id);

        Task<int> Create(BlogDetail model);

        Task<int> Update(BlogDetail model);

        Task<int> DeleteById(IEnumerable<Guid> id);
    }
}