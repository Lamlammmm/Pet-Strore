﻿using Pet_Store.Data.Entities;

namespace PetStore.Service.MenuItemService
{
    public interface IMenuItemService
    {
        Task<IList<MenuItem>> GetAll();

        Task<MenuItem> GetById(Guid id);

        Task<int> Create(MenuItem model);

        Task<int> Update(MenuItem model);

        Task<int> DeleteById(IEnumerable<Guid> ids);
    }
}