using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Model.BaseEntity;
using PetStore.Model.Files;

namespace PetStore.Model.Banner
{
    public class BannerModel : BaseEntityModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int TypeBanner { get; set; }
        public IList<SelectListItem>? AvailableTypeBanner { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public BannerModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}