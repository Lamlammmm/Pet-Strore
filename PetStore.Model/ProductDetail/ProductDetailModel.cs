using Microsoft.AspNetCore.Http;
using PetStore.Model.BaseEntity;
using PetStore.Model.Files;

namespace PetStore.Model.ProductDetail
{
    public class ProductDetailModel : BaseEntityModel
    {
        public Guid ProductId { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public Guid VoteId { get; set; }
        public int Qualyti { get; set; }
        public int PriceDetail { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public ProductDetailModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}