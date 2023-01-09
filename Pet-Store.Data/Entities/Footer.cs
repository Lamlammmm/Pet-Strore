using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Store.Data.Entities
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [MaxLength]
        public string Link { get; set; }
    }
}