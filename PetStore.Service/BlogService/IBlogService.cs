using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.About;
using PetStore.Model.Blog;

namespace PetStore.Service
{
    public interface IBlogService
    {
        Task<IList<Blog>> GetAll();

        Task<Blog> GetById(Guid id);

        Task<int> Create(Blog model);

        Task<int> Update(Blog model);

        Task<int> DeleteById(IEnumerable<Guid> id);
        Task<ApiResult<Pagingnation<Blog>>> GetPaging(BlogSeachContext ctx);
    }
}