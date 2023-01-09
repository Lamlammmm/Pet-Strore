using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pet_Store.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        public Guid GroupUserId { get; set; }

        public Guid? ERPUserId { get; set; }
        public bool Active { get; set; }

        public string? ChucVuId { get; set; }

        public string? Code { get; set; }
    }
}