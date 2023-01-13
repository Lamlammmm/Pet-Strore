using Pet_Store.Data.Entities;

namespace PetStore.Service
{
    public interface IVoucherCodeService
    {
        Task<IList<VoucherCode>> GetAll();

        Task<VoucherCode> GetById(Guid id);

        Task<int> Create(VoucherCode model);

        Task<int> Update(VoucherCode model);

        Task<int> DeleteById(Guid id);

        Task<int> DeleteByIds(IEnumerable<Guid> ids);
    }
}