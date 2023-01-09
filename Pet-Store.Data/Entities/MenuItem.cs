using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("MenuItem")]
    public class MenuItem : BaseEntity
    { 
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string MenuName { get; set; }

        public int GhortOrder { get; set; }
        public Guid PanID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Icon { get; set; }
    }
}