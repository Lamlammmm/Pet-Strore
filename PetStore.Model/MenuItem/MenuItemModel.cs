using PetStore.Model.BaseEntity;

namespace PetStore.Model.MenuItem
{
    public class MenuItemModel : BaseEntityModel
    {
        public string MenuName { get; set; }

        public int GhortOrder { get; set; }

        public Guid PanID { get; set; }

        public string Icon { get; set; }

        public int TypeMenu { get; set; }
    }
}