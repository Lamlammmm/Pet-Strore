using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Comment;

namespace PetStore.Service
{
    public interface ICommentService
    {
        Task<IList<Comment>> GetAll();

        Task<Comment> GetById(Guid id);

        Task<ApiResult<Pagingnation<Comment>>> GetAllPaging(CommentSeachContext ctx);

        Task<int> Create(Comment model);
    }
}