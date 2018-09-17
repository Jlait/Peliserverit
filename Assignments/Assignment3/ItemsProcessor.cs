using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3
{

    public class ItemsProcessor
    {
        IRepository repo;

        public ItemsProcessor(IRepository repository)
        {
            repo = repository;
        }

        public Task<Item> GetItem(Guid id)
        {
            return repo.GetItem(id);
        }

        public Task<Item[]> GetAll()
        {
            return repo.GetAllItems();
        }


        public async Task<Item> Create(Guid playerID, NewItem item)
        {
            Item i = new Item();
            
            Player p = await repo.Get(item.OwningPlayer);

            
            i.OwningPlayer = item.OwningPlayer;
            
 
            if (item.ItemType == "Sword" && p.Level < 3)
            {
                throw new RuleNotFollowedException();
            }

            i.Level = item.Level;
            i.ItemID = Guid.NewGuid();
            i.ItemType = item.ItemType;
            i.CreationDate = DateTime.Now;


            
            return await repo.Create(p.Id, i);
        }

        public Task<Item> Modify(Guid id, ModifiedItem item)
        {
           
            if(item.ItemType == "Sword" && item.player.Level < 3)
            {
                throw new RuleNotFollowedException();
            }
            return repo.Modify(id, item);
        }

        public Task<Item> DeleteItem(Guid id)
        {
            return repo.DeleteItem(id);
        }
    }
}
