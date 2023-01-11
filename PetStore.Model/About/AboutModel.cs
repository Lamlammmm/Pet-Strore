using Microsoft.AspNetCore.Http;
using PetStore.Model.BaseEntity;
using PetStore.Model.Files;

namespace PetStore.Model.About
{
    public class AboutModel : BaseEntityModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public AboutModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}