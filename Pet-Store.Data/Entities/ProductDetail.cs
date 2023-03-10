using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("ProductDetail")]
    public class ProductDetail : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Content { get; set; }

        public int Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Image { get; set; }
        public Guid VoteID { get; set; }
        public int Quality { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}