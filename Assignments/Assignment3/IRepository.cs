﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Item> GetItem(Guid id);
        Task<Item[]> GetAllItems();
        Task<Item> Create(Guid id, Item item);
        Task<Item> Modify(Guid id, ModifiedItem item);
        Task<Item> DeleteItem(Guid id);
    }
}
