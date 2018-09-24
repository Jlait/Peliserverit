using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    class InMemoryRepository : IRepository
    {
        List<Player> playerList = new List<Player>();
        List<Item> itemList = new List<Item>();

        public InMemoryRepository() {

            Player p = new Player();
            p.Id = Guid.NewGuid();
            p.IsBanned = false;
            p.Level = 3;
            p.Name = "Yorma";
            p.Score = 9001;
            p.Items = null;
            playerList.Add(p);

            Item i = new Item();
            i.ItemID = Guid.NewGuid();
            i.ItemType = "Sword";
            i.Level = 30;
            i.OwningPlayer = p.Id;
            itemList.Add(i);

        }



        public Task<Player> Create(Player player)
        {
            playerList.Add(player);
            return Task.FromResult(player);
        }

        public Task<Item> CreateItem(Guid id, Item item)
        {
            foreach (var i in playerList)
            {
                if (i.Id == id)
                {
                    i.Items.Add(item);
                }
            }
            itemList.Add(item);
            return Task.FromResult(item);
        }

        public Task<Player> Delete( Guid id)
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

        public Task<Item> DeleteItem(Guid Playerid, Guid id)
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
    

        public  Task<Player> GetPlayer(Guid id)
        {
            Player player= null;
            foreach (Player p in playerList)
            {
                if (p.Id == id)
                {
                    player = p;
                    return Task.FromResult(player);
                }
            }
            
            return  Task.FromResult(player);
        }

        public Task<Player[]> GetAllPlayers()
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

        public Task<Item> GetItem(Guid Playerid, Guid id)
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

        public Task<Item[]> GetAllItems(Guid Playerid)
        {
            return Task.FromResult(itemList.ToArray());
        }

        public Task<Item> Modify(Guid Playerid, Guid id, ModifiedItem item)
        {
            foreach (Item i in itemList)
            {
                if (i.ItemID == id)
                {
                    i.OwningPlayer = item.player.Id;
                    return Task.FromResult(i);
                }
            }
            return null;
        }
    }
}
