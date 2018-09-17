using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{
    class InMemoryRepository : IRepository
    {
        List<Player> playerList = new List<Player>();
        List<Item> itemList = new List<Item>();
        public InMemoryRepository() {

            Player p = new Player();
            p.Id = Guid.NewGuid();
            p.IsBanned = false;
            p.Level = 2;
            p.Name = "Yorma";
            p.Score = 9001;
            playerList.Add(p);

            Item i = new Item();
            i.ItemID = Guid.NewGuid();
            i.ItemType = "Sword";
            i.Level = 30;
            i.OwningPlayer = null;
            itemList.Add(i);

        }



        public Task<Player> Create(Player player)
        {
            playerList.Add(player);
            return Task.FromResult(player);
        }

        public Task<Item> Create(Item item)
        {
            itemList.Add(item);
            return Task.FromResult(item);
        }

        public Task<Player> Delete(Guid id)
        {
            foreach (Player p in playerList)
            {
                if (p.Id == id)
                {
                    playerList.Remove(p);
                    return Task.FromResult(p);
                }
            }
            return null; 
        }

        public Task<Item> DeleteItem(Guid id)
        {
            foreach (Item item in itemList)
            {
                if (item.ItemID == id)
                {
                    itemList.Remove(item);
                    return Task.FromResult(item);
                }
            }
            return null;
        }
    

        public Task<Player> Get(Guid id)
        {
            foreach (Player p in playerList)
            {
                if (p.Id == id)
                {
                    return Task.FromResult(p);
                }
            }
            return null;
        }

        public Task<Player[]> GetAll()
        {
            return Task.FromResult(playerList.ToArray());
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            foreach (Player p in playerList)
            {
                if (p.Id == id)
                {
                    p.Score = player.Score;
                    return Task.FromResult(p);
                }
            }
            return null;
        }

        public Task<Item> GetItem(Guid id)
        {
            foreach (Item i in itemList)
            {
                if (i.ItemID == id)
                {
                    return Task.FromResult(i);
                }
            }
            return null;
        }

        public Task<Item[]> GetAllItems()
        {
            return Task.FromResult(itemList.ToArray());
        }

        public Task<Item> Modify(Guid id, ModifiedItem item)
        {
            foreach (Item i in itemList)
            {
                if (i.ItemID == id)
                {
                    i.OwningPlayer = item.player;
                    return Task.FromResult(i);
                }
            }
            return null;
        }
    }
}
