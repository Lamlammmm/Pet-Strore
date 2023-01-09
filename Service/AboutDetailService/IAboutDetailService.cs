using Pet_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AboutDetailService
{
    public interface IAboutDetailService
    {
        Task<IList<About>> GetAll();
        Task<About> GetById(Guid id);
        Task<int> Create(About model);
        Task<int> Update(About model);
        Task<int> DeleteById(Guid id);
    }
}
