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

        public Task<Item> Create(NewItem item)
        {
            Item i = new Item();


            i.OwningPlayer = item.OwningPlayer;
            if (item.ItemType == "Sword" && item.OwningPlayer.Level < 3)
            {
                throw new RuleNotFollowedException();
            }

            i.ItemType = item.ItemType;
            i.CreationDate = DateTime.Now;

            return repo.Create(i);
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
