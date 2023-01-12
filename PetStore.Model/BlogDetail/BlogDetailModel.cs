using PetStore.Model.BaseEntity;

namespace PetStore.Model.BlogDetail
{
    public class BlogDetailModel : BaseEntityModel
    {
        public string ContentDetail { get; set; }
        public Guid CommentId { get; set; }
        public Guid BlogId { get; set; }
    }
}