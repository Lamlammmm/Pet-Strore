using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("Tag")]
    public class Tag : BaseEntity
    {
        [Required]
        public Guid BlogId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string NameTag { get; set; }
    }
}