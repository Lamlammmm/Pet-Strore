using System.ComponentModel.DataAnnotations;

namespace Pet_Store.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}