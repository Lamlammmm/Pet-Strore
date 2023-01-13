using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Model.Files;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Model
{
    public class UserModel
    {
        public string? GuidId { get; set; }

        public Guid GroupUserId { get; set; }

        public string? GroupUserName { get; set; }

        [Required]
        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public IList<SelectListItem>? AvailableGroupUser { get; set; }

        public Guid? ERPUserId { get; set; }

        public Guid? ERPUserName { get; set; }

        public IList<SelectListItem>? AvailableERPUser { get; set; }

        public bool Active { get; set; }

        public string? ChucVuId { get; set; }

        public string? ChucVuName { get; set; }

        public IList<SelectListItem>? AvailableChucVu { get; set; }

        public string? Code { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

        public UserModel()
        {
            FilesModels = new List<FilesModel>();
        }
    }
}