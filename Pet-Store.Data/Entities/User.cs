using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pet_Store.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
        }

        public User(string id, string userName, string firstName, string lastName,
            string email, string phoneNumber, DateTime dob)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Dob = dob;
        }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }

        public Guid GroupUserId { get; set; }

        public Guid? ERPUserId { get; set; }
        public bool Active { get; set; }

        public string? ChucVuId { get; set; }

        public string? Code { get; set; }
    }
}