using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;

namespace PetStore.Service
{
    public class ServicePetService : IServicePetService
    {
        private readonly PetStoreDbContext _dbContext;

        public ServicePetService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(ServicePet model)
        {
            var item = new ServicePet()
            {
                Id = model.Id,
                Content = model.Content,
                Icon = model.Icon,
                Title = model.Title,
            };
            await _dbContext.ServicesPet.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteById(Guid id)
        {
            var item = await _dbContext.ServicesPet.FindAsync(id);
            _dbContext.ServicesPet.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.ServicesPet.FindAsync(item);
                _dbContext.ServicesPet.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<ServicePet>> GetAll()
        {
            var list = await _dbContext.ServicesPet.ToListAsync();
            return list;
        }

        public async Task<ApiResult<Pagingnation<ServicePet>>> GetAllPaging(ServicePetSeachContext ctx)
        {
            var query = from a in _dbContext.ServicesPet
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Title.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new ServicePet()
                {
                    Title = u.a.Title,
                    Content = u.a.Content,
                    Icon = u.a.Icon,
                    Id = u.a.Id,
                })
                .ToListAsync();
            var pagination = new Pagingnation<ServicePet>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<ServicePet>>(pagination);
        }

        public async Task<ServicePet> GetById(Guid id)
        {
            var item = await _dbContext.ServicesPet.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(ServicePet model)
        {
            var item = await _dbContext.ServicesPet.FirstOrDefaultAsync(p => p.Id == model.Id);
            item.Title = model.Title;
            item.Content = model.Content;
            item.Icon = model.Icon;
            _dbContext.ServicesPet.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}