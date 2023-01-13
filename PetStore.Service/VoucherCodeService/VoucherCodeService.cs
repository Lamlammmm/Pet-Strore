using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;

namespace PetStore.Service.VoucherCodeService
{
    public class VoucherCodeService : IVoucherCodeService
    {
        private readonly PetStoreDbContext _dbContext;

        public VoucherCodeService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(VoucherCode model)
        {
            var item = new VoucherCode()
            {
                Id = Guid.NewGuid(),
                Code = model.Code,
                Dieukien = model.Dieukien,
            };
            await _dbContext.VoucherCodes.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteById(Guid id)
        {
            var item = await _dbContext.VoucherCodes.FindAsync(id);
            _dbContext.VoucherCodes.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> ids)
        {
            foreach (var item in ids)
            {
                var finditem = await _dbContext.VoucherCodes.FindAsync(item);
                _dbContext.VoucherCodes.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<VoucherCode>> GetAll()
        {
            var list = await _dbContext.VoucherCodes.ToListAsync();
            return list;
        }

        public async Task<VoucherCode> GetById(Guid id)
        {
            var item = await _dbContext.VoucherCodes.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(VoucherCode model)
        {
            var item = await _dbContext.VoucherCodes.FirstOrDefaultAsync(p => p.Id == model.Id);
            item.Code = model.Code;
            item.Dieukien = model.Dieukien;
            _dbContext.VoucherCodes.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}