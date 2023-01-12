using PetStore.Model.BaseEntity;

namespace PetStore.Model.AboutDetail
{
    public class AboutDetailModel : BaseEntityModel
    {
        public string CatagoryDetail { get; set; }

        public string ContenDetail { get; set; }

        public Guid AboutId { get; set; }
    }
}