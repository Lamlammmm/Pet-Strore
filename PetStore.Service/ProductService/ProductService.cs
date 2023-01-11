using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model.Product;

namespace PetStore.Service
{
    public class ProductService : IProducService
    {
        private readonly PetStoreDbContext _dbContext;

        public ProductService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Product model)
        {
            var item = new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Image = model.Image,
                Price = model.Price,
            };
            await _dbContext.Products.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.Products.FindAsync(id);
                _dbContext.Products.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Product>> GetAll()
        {
            var list = await _dbContext.Products.ToListAsync();
            return list;
        }

        public async Task<ApiResult<Pagingnation<Product>>> GetAllPaging(ProductSeachContext ctx)
        {
            var query = from a in _dbContext.Products
                        select new { a };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Name.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new Product()
                {
                    Id = u.a.Id,
                    Name = u.a.Name,
                    Image = u.a.Image,
                    Price = u.a.Price
                })
                .ToListAsync();
            var pagination = new Pagingnation<Product>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<Product>>(pagination);
        }

        public async Task<Product> GetById(Guid id)
        {
            var item = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(Product model)
        {
            var item = await _dbContext.Products.FindAsync(model.Id);
            item.Name = model.Name;
            item.Image = model.Image;
            item.Price = model.Price;
            _dbContext.Products.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}