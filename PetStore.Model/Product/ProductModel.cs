using Microsoft.AspNetCore.Http;
using PetStore.Model.BaseEntity;
using PetStore.Model.Files;

namespace PetStore.Model
{
    public class ProductModel : BaseEntityModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string? ImageDetail { get; set; }
        public string? Content { get; set; }
        public Guid? VoteId { get; set; }
        public int? PriceDetail { get; set; }
        public int? Qualyti { get; set; }
        public Guid ProductId { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public ProductModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}