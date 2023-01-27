using PetStore.Model.BaseEntity;

namespace PetStore.Model.Files
{
    public class FilesModel : BaseEntityModel
    {
        public string FileName { get; set; }

        public string? Path { get; set; }

        public decimal Size { get; set; }

        public string? Extension { get; set; }

        public string? MimeType { get; set; }

        public Guid? AboutId { get; set; }
        public Guid? BannerId { get; set; }
        public Guid? ProductId { get; set; }
    }
}