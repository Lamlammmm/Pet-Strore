using Pet_Store.Data.Entities;
using PetStore.Model.Files;

namespace PetStore.Service
{
    public interface IFileBannerService
    {
        Task<long> InsertAsync(IList<Files> entities, Guid id);

        Task<Files> GetByIdAsync(Guid id);

        Task<long> UpdateAsync(IList<Files> entities, Guid id);

        Task<int> Delete(Guid id);

        Task<List<FilesModel>> GetFilesAdmin(Guid id);

        Task<Files> GetByNameAsync(Guid id);
    }
}