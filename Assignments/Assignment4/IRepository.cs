
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    public interface IRepository
    {
        Task<Player> GetPlayer(Guid id);
        Task<Player[]> GetAllPlayers();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Item> GetItem(Guid Playerid, Guid id);
        Task<Item[]> GetAllItems(Guid Playerid);
        Task<Item> CreateItem(Guid id, Item item);
        Task<Item> Modify(Guid Playerid, Guid id, ModifiedItem item);
        Task<Item> DeleteItem(Guid Playerid, Guid id);
    }
}
