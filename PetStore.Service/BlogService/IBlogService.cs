using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.About;
using PetStore.Model.Blog;

namespace PetStore.Service
{
    public interface IBlogService
    {
        Task<IList<Blog>> GetAll();

        Task<BlogModel> GetById(Guid id);

        Task<int> Create(BlogModel model);

        Task<int> Update(BlogModel model);

        Task<int> DeleteByIds(IEnumerable<Guid> id);
        Task<int> Delete(Guid id);
        Task<ApiResult<Pagingnation<BlogModel>>> GetPaging(BlogSeachContext ctx);
    }
}