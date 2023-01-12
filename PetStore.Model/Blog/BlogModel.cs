using Microsoft.AspNetCore.Http;
using PetStore.Model.BaseEntity;
using PetStore.Model.Files;

namespace PetStore.Model.Blog
{
    public class BlogModel : BaseEntityModel
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ContentDetail { get; set; }
        public Guid? CommentId { get; set; }
        public Guid? BlogId { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public BlogModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}