using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{

    public class ItemsProcessor
    {
        IRepository repo;

        public ItemsProcessor(IRepository repository)
        {
            repo = repository;
        }

        public Task<Item> GetItem(Guid Playerid, Guid id)
        {
            return repo.GetItem(Playerid, id);
        }

        public Task<Item[]> GetAllItems(Guid Playerid)
        {
            return repo.GetAllItems(Playerid);
        }


        public async Task<Item> Create(Guid playerID, NewItem item)
        {
            Item i = new Item();
            
            Player p = await repo.GetPlayer(item.OwningPlayer);

            
            i.OwningPlayer = item.OwningPlayer;
            
 
            if (item.ItemType == "Sword" && p.Level < 3)
            {
                throw new RuleNotFollowedException();
            }

            i.Level = item.Level;
            i.ItemID = Guid.NewGuid();
            i.ItemType = item.ItemType;
            i.CreationDate = DateTime.Now;


            
            return await repo.CreateItem(p.Id, i);
        }

        public Task<Item> Modify(Guid PlayerId, Guid id, ModifiedItem item)
        {
           
            if(item.ItemType == "Sword" && item.player.Level < 3)
            {
                throw new RuleNotFollowedException();
            }
            return repo.Modify(PlayerId, id, item);
        }

        public Task<Item> DeleteItem(Guid Playerid, Guid id)
        {
            return repo.DeleteItem(Playerid, id);
        }
    }
}
