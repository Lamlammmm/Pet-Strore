using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public class UserContactService : IUserContactService
    {
        private readonly PetStoreDbContext _dbContext;

        public UserContactService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(UserContact model)
        {
            var item = new UserContact()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                Subject = model.Subject
            };
            await _dbContext.UserContacts.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}