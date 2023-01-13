using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("Files")]
    public class Files : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string FileName { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string? Path { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal Size { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Extension { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? MimeType { get; set; }

        public Guid? AboutId { get; set; }
        public Guid? BannerId { get; set; }
    }
}