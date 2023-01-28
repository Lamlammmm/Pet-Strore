using Microsoft.EntityFrameworkCore;
using Pet_Store.Common.Common;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Common.Common;
using PetStore.Model;

namespace PetStore.Service
{
    public class ProductService : IProducService
    {
        private readonly PetStoreDbContext _dbContext;

        public ProductService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(ProductModel model)
        {
            var item = new Product()
            {
                Id = (Guid)model.Id,
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

        public async Task<ApiResult<Pagingnation<ProductModel>>> GetAllPaging(ProductSeachContext ctx)
        {
            var query = from a in _dbContext.Products
                        join c in _dbContext.ProductDetails on a.Id equals c.ProductId into pt
                        from tp in pt.DefaultIfEmpty()
                        join v in _dbContext.VoucherCodes on tp.VoteID equals v.Id into vt
                        from tv in vt.DefaultIfEmpty()
                        select new { a, tp, tv };
            if (!string.IsNullOrEmpty(ctx.Keyword))
            {
                query = query.Where(x => x.a.Name.Contains(ctx.Keyword));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((ctx.PageIndex - 1) * ctx.PageSize)
                .Take(ctx.PageSize)
                .Select(u => new ProductModel()
                {
                    Id = u.a.Id,
                    Name = u.a.Name,
                    Image = u.a.Image,
                    Price = u.a.Price,
                    ProductId = u.tp.ProductId,
                    ImageDetail = u.tp.Image,
                    Content = u.tp.Content,
                    VoteId = u.tp.VoteID,
                    VoteName = $"{u.tv.Code} - {u.tv.Dieukien}",
                    Qualyti = u.tp.Quality
                })
                .ToListAsync();
            var pagination = new Pagingnation<ProductModel>
            {
                Items = items,
                TotalRecords = totalRecords,
                PageIndex = ctx.PageIndex,
                PageSize = ctx.PageSize,
            };

            return new ApiSuccessResult<Pagingnation<ProductModel>>(pagination);
        }

        public async Task<ProductModel> GetById(Guid id)
        {
            var query = from a in _dbContext.Products
                        join c in _dbContext.ProductDetails on a.Id equals c.ProductId into pt
                        from tp in pt.DefaultIfEmpty()
                        where a.Id == id
                        select new { a, tp };
            var entity = await query.Select(u => new ProductModel()
            {
                Id = u.a.Id,
                Name = u.a.Name,
                Image = u.a.Image,
                Price = u.a.Price,
                ProductId = u.tp.ProductId,
                ImageDetail = u.tp.Image,
                Content = u.tp.Content,
                VoteId = u.tp.VoteID,
                Qualyti = u.tp.Quality
            }).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<int> Update(ProductModel model)
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