﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IRepository
    {
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);
    }
}
