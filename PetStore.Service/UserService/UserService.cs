using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Model;

namespace PetStore.Service
{
    public class UserService : IUserService
    {
        private readonly PetStoreDbContext _dbContext;

        public UserService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserModel model)
        {
            var hashedPassword = new PasswordHasher<UserModel>().HashPassword(new UserModel(), model.PasswordHash);
            var item = new User()
            {
                AccessFailedCount = (int)model.AccessFailedCount,
                UserName = model.UserName,
                Id = model.Id.ToString(),
                Active = model.Active,
                ChucVuId = model.ChucVuId,
                Code = model.Code,
                ConcurrencyStamp = model.ConcurrencyStamp,
                Dob = model.Dob,
                Email = model.Email,
                FirstName = model.FirstName,
                EmailConfirmed = model.EmailConfirmed,
                ERPUserId = model.ERPUserId,
                GroupUserId = model.GroupUserId,
                LastName = model.LastName,
                LockoutEnabled = model.LockoutEnabled,
                LockoutEnd = model.LockoutEnd,
                NormalizedEmail = model.NormalizedEmail,
                NormalizedUserName = model.NormalizedUserName,
                PasswordHash = hashedPassword,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
                SecurityStamp = GenerateSecurityStamp(),
                TwoFactorEnabled = model.TwoFactorEnabled,
                Avatar = model.Avatar,
            };
            await _dbContext.Users.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        private Func<string> GenerateSecurityStamp = delegate ()
        {
            var guid = Guid.NewGuid();
            return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2")));
        };

        public async Task<int> Delete(string id)
        {
            var item = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<string> ids)
        {
            foreach (var item in ids)
            {
                var finditem = await _dbContext.Users.FindAsync(item);
                _dbContext.Users.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<User>> GetAll()
        {
            var list = await _dbContext.Users.ToListAsync();
            return list;
        }

        public async Task<User> GetById(string id)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(UserModel model)
        {
            var hashedPassword = new PasswordHasher<UserModel>().HashPassword(new UserModel(), model.PasswordHash);
            var item = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == model.Id.ToString());
            item.AccessFailedCount = (int)model.AccessFailedCount;
            item.UserName = model.UserName;
            item.Active = model.Active;
            item.ChucVuId = model.ChucVuId;
            item.Code = model.Code;
            item.ConcurrencyStamp = model.ConcurrencyStamp;
            item.Dob = model.Dob;
            item.Email = model.Email;
            item.FirstName = model.FirstName;
            item.EmailConfirmed = model.EmailConfirmed;
            item.ERPUserId = model.ERPUserId;
            item.GroupUserId = model.GroupUserId;
            item.LastName = model.LastName;
            item.LockoutEnabled = model.LockoutEnabled;
            item.LockoutEnd = model.LockoutEnd;
            item.NormalizedEmail = model.NormalizedEmail;
            item.NormalizedUserName = model.NormalizedUserName;
            item.PasswordHash = hashedPassword;
            item.PhoneNumber = model.PhoneNumber;
            item.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            item.SecurityStamp = GenerateSecurityStamp();
            item.TwoFactorEnabled = model.TwoFactorEnabled;
            item.Avatar = model.Avatar;
            _dbContext.Users.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}