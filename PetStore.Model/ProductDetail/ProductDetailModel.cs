using PetStore.Model.BaseEntity;

namespace PetStore.Model.ProductDetail
{
    public class ProductDetailModel : BaseEntityModel
    {
        public Guid ProductId { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public Guid VoteId { get; set; }
        public int Qualyti { get; set; }
    }
}