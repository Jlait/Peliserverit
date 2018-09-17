using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2
{
    class InMemoryRepository : IRepository
    {
        List<Player> playerList = new List<Player>();

        public InMemoryRepository() { }

        public Task<Player> Create(Player player)
        {
            playerList.Add(player);
            return Task.FromResult(player);
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
    }
}
