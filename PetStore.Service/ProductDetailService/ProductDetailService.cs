using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Model.ProductDetail;

namespace PetStore.Service
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly PetStoreDbContext _dbContext;

        public ProductDetailService(PetStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(ProductDetailModel model)
        {
            var item = new ProductDetail()
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                Image = model.Image,
                Price = model.PriceDetail,
                ProductId = model.ProductId,
                Quality = model.Qualyti,
                VoteID = model.VoteId
            };
            await _dbContext.ProductDetails.AddAsync(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _dbContext.ProductDetails.FindAsync(id);
            _dbContext.ProductDetails.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteByIds(IEnumerable<Guid> id)
        {
            foreach (var item in id)
            {
                var finditem = await _dbContext.ProductDetails.FindAsync(item);
                _dbContext.ProductDetails.Remove(finditem);
            }
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<IList<ProductDetail>> GetAll()
        {
            var list = await _dbContext.ProductDetails.ToListAsync();
            return list;
        }

        public async Task<ProductDetail> GetById(Guid id)
        {
            var item = await _dbContext.ProductDetails.FirstOrDefaultAsync(p => p.Id == id);
            return item;
        }

        public async Task<int> Update(ProductDetailModel model)
        {
            var item = await _dbContext.ProductDetails.FirstOrDefaultAsync(p => p.ProductId == model.ProductId);
            item.Price = (int)model.PriceDetail;
            item.Image = model.Image;
            item.Content = model.Content;
            item.VoteID = model.VoteId;
            item.Quality = model.Qualyti;
            _dbContext.ProductDetails.Update(item);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}