using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("AboutDetail")]
    public class AboutDetail : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string CatagoryDetail { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string ContenDetail { get; set; }

        [Required]
        public Guid AboutId { get; set; }
    }
}