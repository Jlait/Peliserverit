using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace assignment2
{
    class InMemoryRepository : IRepository
    {
        public Task<Player> Create(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Player[]> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
