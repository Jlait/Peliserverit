using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment4
{
    public class PlayersProcessor
    {
        IRepository repo;

        public PlayersProcessor(IRepository repository)
        {
            repo = repository;
        }

        public PlayersProcessor()
        {
        }

        public Task<Player> Get(Guid id)
        {
            return repo.GetPlayer(id);
        }

        public Task<Player[]> GetAll()
        {
            return repo.GetAllPlayers();
        }

        public Task<Player> Create(NewPlayer player)
        {
            Player p = new Player();
            p.Name = player.Name;
            p.Id = Guid.NewGuid();
            p.CreationTime = DateTime.Now;
            return repo.Create(p);
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return repo.Modify(id, player);
        }

        public Task<Player> Delete(Guid id)
        {
            return repo.Delete(id);
        }
    }
}
