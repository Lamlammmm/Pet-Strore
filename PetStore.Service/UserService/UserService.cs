using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class UserService : IUserService
    {
        private readonly PetStoreDbContext _dbContext;

        public UserService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(User model)
        {
            var item = new User()
            {
                AccessFailedCount = model.AccessFailedCount,
                UserName = model.UserName,
                Id = model.Id,
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
                PasswordHash = model.PasswordHash,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = model.PhoneNumberConfirmed,
                SecurityStamp = model.SecurityStamp,
                TwoFactorEnabled = model.TwoFactorEnabled,
            };
            await _dbContext.SaveChangesAsync();
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> ids)
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

        public async Task<int> Update(User model)
        {
            var item = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == model.Id);
            item.AccessFailedCount = model.AccessFailedCount;
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
            item.PasswordHash = model.PasswordHash;
            item.PhoneNumber = model.PhoneNumber;
            item.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
            item.SecurityStamp = model.SecurityStamp;
            item.TwoFactorEnabled = model.TwoFactorEnabled;
            _dbContext.Users.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}