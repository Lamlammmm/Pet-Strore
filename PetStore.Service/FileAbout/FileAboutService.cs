using Microsoft.EntityFrameworkCore;
using Pet_Store.Data.EF;
using Pet_Store.Data.Entities;
using PetStore.Model.Files;

namespace PetStore.Service
{
    public class FileAboutService : IFileAboutService
    {
        #region Fields

        private readonly PetStoreDbContext _context;

        public FileAboutService(PetStoreDbContext context)
        {
            _context = context;
        }

        #endregion Fields

        #region Method

        public async Task<long> InsertAsync(IList<Files> entities, Guid id)
        {
            var list = new List<Files>();
            foreach (var item in entities)
            {
                var files = new Files()
                {
                    FileName = item.FileName,
                    Extension = item.Extension,
                    MimeType = item.MimeType,
                    Path = item.Path,
                    Size = item.Size,
                    AboutId = id,
                };

                files.Id = Guid.NewGuid();
                list.Add(files);
            }

            await _context.Files.AddRangeAsync(list);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<long> UpdateAsync(IList<Files> entities, Guid id)
        {
            var itemFiles = await _context.Files.FirstOrDefaultAsync(x => x.AboutId.Equals(id));
            var list = new List<Files>();
            foreach (var file in entities)
            {
                itemFiles.FileName = file.FileName;
                itemFiles.Extension = file.Extension;
                itemFiles.MimeType = file.MimeType;
                itemFiles.Path = file.Path;
                itemFiles.Size = file.Size;
                file.Id = itemFiles.Id;
                file.AboutId = itemFiles.AboutId;
            }

            list.Add(itemFiles);
            _context.Files.Update(itemFiles);

            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> Delete(Guid id)
        {
            var item = await _context.Files.FirstOrDefaultAsync(x => x.AboutId.Equals(id));

            _context.Files.Remove(item);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        #endregion Method

        #region List

        public async Task<List<FilesModel>> GetFilesAdmin(Guid id)
        {
            //1. Select join
            var query = from p in _context.Files
                        where p.AboutId == id
                        select new { p };

            var data = await query.OrderByDescending(x => x.p.FileName)
                .Select(x => new FilesModel()
                {
                    Id = x.p.Id,
                    FileName = x.p.FileName,
                    AboutId = x.p.AboutId,
                    Size = x.p.Size,
                    Extension = x.p.Extension,
                    MimeType = x.p.MimeType,
                    Path = x.p.Path
                }).ToListAsync();

            return data;
        }

        public async Task<Files> GetByIdAsync(Guid id)
        {
            var query =
                from x in _context.Files
                where x.AboutId == id
                select x;

            return await query.FirstOrDefaultAsync();
        }

        public Task<Files> GetByNameAsync(Guid id)
        {
            var query =
                from x in _context.Files
                where x.AboutId == id
                select x;

            return query.FirstOrDefaultAsync();
        }

        #endregion List
    }
}